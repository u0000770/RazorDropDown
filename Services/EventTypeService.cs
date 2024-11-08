namespace RazorDropDown.Services
{
    public class EventTypeService1
    {

        private readonly HttpClient _client;

        public EventTypeService1(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<EventTypeDTO>> GetEventTypesAsync()
        {
            var response = await _client.GetAsync("api/eventtypes");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<EventTypeDTO>>();
            }
            return new List<EventTypeDTO>();
        }
    }
}
