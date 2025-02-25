using Mindlift.API_Data;
using Mindlift.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mindlift.API_Data;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace Mindlift.Pages
{
    public class DogDetailsModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string? breedName { get; set; }

        [BindProperty(SupportsGet = true)]
        public API_Data.DogBreed? DogDetails { get; set; }
        public async Task OnGetAsync()
        {
            var allDogBreeds = await DogBreedService.FetchBreedsAsync();
            DogDetails = allDogBreeds.Where(row => row?.General?.Name == breedName).FirstOrDefault();

        }
    }
}
