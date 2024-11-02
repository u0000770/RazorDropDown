using System.ComponentModel.DataAnnotations;

namespace RazorDropDown.Services
{
    public class EventTypeDTO
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public interface IVenueService
    {
        Task<List<EventTypeDTO>> getEventTypes();
        Task<EventTypeDTO> getEventType(string id);
    }

}
