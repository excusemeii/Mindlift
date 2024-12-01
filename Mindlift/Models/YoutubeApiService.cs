using Google.Apis.YouTube.v3;
using Google.Apis.Services;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore; // Import this for EF Core
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mindlift.Data;

namespace Mindlift.Models
{
    public class YouTubeApiService
    {
        private readonly YouTubeService _youtubeService;
        private readonly ApplicationDbContext _context; // Add DbContext for database operations

        // Constructor to initialize the YouTubeService with the API key
        public YouTubeApiService(IConfiguration configuration, ApplicationDbContext context)
        {
            var apiKey = configuration["YouTube:ApiKey"];
            _context = context;

            // Initialize YouTubeService with API key
            _youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = "Mindlift YouTube Integration"
            });
        }

        // Method to search for videos on YouTube and save them to the database
        public async Task<IList<SearchResult>> SearchVideosAsync(string query, int maxResults = 5)
        {
            try
            {
                var searchListRequest = _youtubeService.Search.List("snippet");
                searchListRequest.Q = query;
                searchListRequest.MaxResults = maxResults;

                var searchListResponse = await searchListRequest.ExecuteAsync();

                var videoResults = new List<SearchResult>();
                foreach (var item in searchListResponse.Items)
                {
                    if (item.Id.Kind == "youtube#video")
                    {
                        // Save video details to database
                        var video = new YouTubeVideo
                        {
                            VideoId = item.Id.VideoId,
                            Title = item.Snippet.Title,
                            Description = item.Snippet.Description,
                            ThumbnailUrl = item.Snippet.Thumbnails.Default__.Url,
                            ChannelTitle = item.Snippet.ChannelTitle
                        };

                        // Add the video to the database
                        _context.YoutubeVideos.Add(video);
                        await _context.SaveChangesAsync();  // Save the changes to the database

                        videoResults.Add(item);
                    }
                }

                return videoResults;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching YouTube videos: " + ex.Message);
                return new List<SearchResult>();
            }
        }

        // Method to get details of a specific video by its ID and save to database
        public async Task<Video> GetVideoDetailsAsync(string videoId)
        {
            try
            {
                var videosListRequest = _youtubeService.Videos.List("snippet,contentDetails,statistics");
                videosListRequest.Id = videoId;

                var videosListResponse = await videosListRequest.ExecuteAsync();

                if (videosListResponse.Items.Count > 0)
                {
                    var videoItem = videosListResponse.Items[0];

                    // Save the video details to the database
                    var video = new YouTubeVideo
                    {
                        VideoId = videoItem.Id,
                        Title = videoItem.Snippet.Title,
                        Description = videoItem.Snippet.Description,
                        ThumbnailUrl = videoItem.Snippet.Thumbnails.Default__.Url,
                        ChannelTitle = videoItem.Snippet.ChannelTitle,
                        ViewCount = videoItem.Statistics.ViewCount.HasValue ? (int)videoItem.Statistics.ViewCount : 0,
                        LikeCount = videoItem.Statistics.LikeCount.HasValue ? (int)videoItem.Statistics.LikeCount : 0
                    };

                    _context.YoutubeVideos.Add(video);
                    await _context.SaveChangesAsync();

                    return videoItem;
                }
                else
                {
                    Console.WriteLine("Video not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching video details: " + ex.Message);
                return null;
            }
        }
    }
}
