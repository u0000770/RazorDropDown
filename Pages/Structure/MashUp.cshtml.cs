using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDropDown.Services;

namespace RazorDropDown.Pages.Structure
{


    public class EventJokeVM
    {
        public string Title { get; set; }
        public string Joke { get; set; }
    }

    public class MashUpModel : PageModel
    {
        public List<EventJokeVM> VM { get; set; } = new List<EventJokeVM>();
        private readonly EntertainmentService _entertainmentService;


        public MashUpModel(EntertainmentService entertainmentService)
        {
            _entertainmentService = entertainmentService;
        }

        public List<EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();
        public JokeDto Joke { get; set; } = new JokeDto();

        public async Task OnGetAsync()
        {
            // Retrieve event types
            var eventJokes = await _entertainmentService.GetJokesForEvent();

            // Await all tasks and convert results to a list
            VM = eventJokes.Select(item => new EventJokeVM()
            {
                 Title = item.EventTitle,
                Joke = $"{item.Setup}? {item.Punchline}!"
            }).ToList();

        }

       
    }
}
