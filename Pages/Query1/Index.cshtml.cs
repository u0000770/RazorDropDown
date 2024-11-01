using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Query1
{
    public class IndexModel : PageModel
    {

        public string UserName { get; private set; }

        public IActionResult OnGet(string UserName)
        {
           
            if (!string.IsNullOrEmpty(UserName))
            {
                // Redirect to Page 2 with UserName as a query parameter
                return RedirectToPage("Page2", new { userName = UserName });
            }
            return Page();

        }

        public IActionResult OnGetBack(string? UserNameBack)
        {
            if (!string.IsNullOrEmpty(UserNameBack))
            {
                ViewData["UserNameBack"] = UserNameBack;
            }

            return Page();
        }
    }
}

