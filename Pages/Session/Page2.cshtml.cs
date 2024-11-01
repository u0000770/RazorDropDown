using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Session
{
    public class Page2Model : PageModel
    {
        public string UserName { get; set; }

        public void OnGet()
        {
            // Read the session value
            UserName = HttpContext.Session.GetString("UserName");
        }
    }
}
