using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Session
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        public void OnGet()
        {
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
