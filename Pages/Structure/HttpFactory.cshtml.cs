using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDropDown.Services;

namespace RazorDropDown.Pages.Structure
{
    public class HttpFactoryModel : PageModel
    {
        private readonly EventTypeService1 _eventTypeService;

        public List<EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();

        public HttpFactoryModel(EventTypeService1 eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        public async Task OnGetAsync()
        {
            EventTypes = await _eventTypeService.GetEventTypesAsync();
        }
    }
}
