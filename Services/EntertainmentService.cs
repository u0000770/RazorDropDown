using Humanizer;
using RazorDropDown.Pages.Structure;
using static System.Net.Mime.MediaTypeNames;

namespace RazorDropDown.Services
{

    public class EventJoke
    {
        
        public string JokeType { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public string EventTitle { get; set; }
    }

    public class EntertainmentService
    {
        public List<EventJoke> VM { get; set; } = new List<EventJoke>();
        private readonly NamedEventTypeService _eventTypeService;
        private readonly JokeService _jokeApiService;

        public EntertainmentService(NamedEventTypeService eventTypeService, JokeService jokeApiService)
        {
            _eventTypeService = eventTypeService;
            _jokeApiService = jokeApiService;
        }

        public async Task<IEnumerable<EventJoke>> GetJokesForEvent()
        {
            var eventTypes = await _eventTypeService.GetEventTypesAsync();

            // Use Task.WhenAll to await all the joke-fetching tasks concurrently
            var eventJokesTasks = eventTypes.Select(async eventType =>
            {
                var joke = await _jokeApiService.GetRandomJokeAsync();
                return new EventJoke
                {
                    EventTitle = eventType.Title,
                    JokeType = joke.Type,
                    Setup = joke.Setup,
                    Punchline = joke.Punchline,
                };
            });

            /// Using await on Task.WhenAll means that the method will pause here until all joke-fetching tasks finish. 
            ///It will then return an array containing the results of each individual task.
            ///By using Task.WhenAll, all tasks run concurrently instead of sequentially. 
            ///This approach is much faster because it doesn’t wait for each joke to finish before starting the next one.
            var eventJokes = await Task.WhenAll(eventJokesTasks);
            return eventJokes;
        }



    }


}
