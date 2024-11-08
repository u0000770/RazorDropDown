using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDropDown.Services;

namespace RazorDropDown.Pages.Structure
{

    public class TwoServicesModel : PageModel
    {
        private readonly NamedEventTypeService _eventTypeService;
        private readonly JokeService _jokeApiService;

        public TwoServicesModel(NamedEventTypeService eventTypeService, JokeService jokeApiService)
        {
            _eventTypeService = eventTypeService;
            _jokeApiService = jokeApiService;
        }

        public List<EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();
        public JokeDto Joke { get; set; } = new JokeDto();

        public async Task OnGetAsync()
        {
            EventTypes = await _eventTypeService.GetEventTypesAsync();
            Joke = await _jokeApiService.GetRandomJokeAsync();
        }
    }
}
