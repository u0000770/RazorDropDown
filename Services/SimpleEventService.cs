﻿namespace RazorDropDown.Services
{
    public class EventTypeService
    {
        private readonly HttpClient _client;

        public EventTypeService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://thamcovenues.azurewebsites.net/");
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