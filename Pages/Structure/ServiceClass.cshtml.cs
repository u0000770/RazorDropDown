using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDropDown.Services;

namespace RazorDropDown.Pages.Structure
{
    public class ServiceClassModel : PageModel
    {

        private readonly EventTypeService _eventTypeService;

        public List<EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();

        public ServiceClassModel(EventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        public async Task OnGetAsync()
        {
            EventTypes = await _eventTypeService.GetEventTypesAsync();
        }
    }
}
