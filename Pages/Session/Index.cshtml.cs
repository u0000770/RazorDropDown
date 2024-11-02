using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Session
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }

        public void OnGet()
        {
            // Check if the session variable "UserName" exists and retrieve its value
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewData["UserName"] = HttpContext.Session.GetString("UserName"); // Set the session value in ViewData for display
            }
        }

        public IActionResult OnPost()
        {
            // Set the session value with the user's name
            if (!string.IsNullOrEmpty(UserName))
            {
                HttpContext.Session.SetString("UserName", UserName);
            }

            return RedirectToPage("Page2");
        }
    }
}
