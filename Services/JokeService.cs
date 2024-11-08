namespace RazorDropDown.Services
{

    public class JokeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
    }

    public class JokeService
    {
        private readonly HttpClient _client;

        public JokeService(IHttpClientFactory httpClientFactory)
        {
            //_client = client;
            //_client.BaseAddress = new Uri("https://thamcovenues.azurewebsites.net/");
            _client = httpClientFactory.CreateClient("JokeApiClient");
        }

        public async Task<JokeDto> GetRandomJokeAsync()
        {
            var response = await _client.GetAsync("random_joke");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<JokeDto>();
            }
            return null;
        }
    }
}
