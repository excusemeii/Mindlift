using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mindlift.Data;
using Mindlift.Models;
using Newtonsoft.Json.Linq;

namespace Mindlift.Pages.Libraries
{
    public class IndexModel : PageModel
    {
        private readonly Mindlift.Data.ApplicationDbContext _context;
        private static readonly HttpClient client = new HttpClient();

        public IndexModel(Mindlift.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Library> Library { get; set; } = default!;
        public IList<Book> ExternalBooks { get; set; } = new List<Book>();

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            // Fetch data from your database
            Library = await _context.Library.ToListAsync();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                // Construct a generic URL with the search query
                string url = $"https://openlibrary.org/search.json?q={Uri.EscapeDataString(SearchQuery)}";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Ensure the response is successful

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Parse JSON response
                    JObject jsonResponse = JObject.Parse(responseBody);
                    var docs = jsonResponse["docs"];

                    if (docs != null)
                    {
                        // Take the top 3 results
                        foreach (var book in docs.Take(3))
                        {
                            string title = book["title"]?.ToString() ?? "N/A";
                            string author = book["author_name"] != null ? string.Join(", ", book["author_name"].ToObject<string[]>()) : "N/A";
                            string isbn = book["isbn"] != null && book["isbn"].HasValues ? book["isbn"].First.ToString() : "N/A";
                            double? ratings = book["ratings_average"] != null ? (double?)book["ratings_average"] : null;

                            // Create a new Book object
                            ExternalBooks.Add(new Book
                            {
                                Title = title,
                                Author = author,
                                ISBN = isbn,
                                RatingsAverage = ratings
                            });
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    // Handle request errors (log or display error message as needed)
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }
    }

    // Updated Book class
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public double? RatingsAverage { get; set; }
    }
}
