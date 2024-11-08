namespace RazorDropDown.Services
{
    public class NamedEventTypeService
    {
            private readonly HttpClient _client;

            public NamedEventTypeService(IHttpClientFactory httpClientFactory)
            {
                _client = httpClientFactory.CreateClient("EventTypeClient");
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

