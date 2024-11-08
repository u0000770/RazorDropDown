using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDropDown.Services;

namespace RazorDropDown.Pages.Structure
{
    public class PageBasedModel : PageModel
    {

        public List<RazorDropDown.Services.EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();
  

        public async Task OnGetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://thamcovenues.azurewebsites.net/");
                var response = await client.GetAsync("api/eventtypes");
                if (response.IsSuccessStatusCode)
                {
                    EventTypes = await response.Content.ReadFromJsonAsync<List<EventTypeDTO>>();
                }
            }
        }


    }
}
