using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Query2
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string UserNameBack { get; set; }

        public IActionResult OnGet()
        {
       
            if (!string.IsNullOrEmpty(UserName))
            {
                // Redirect to Page 2 with UserName as a query parameter
                return RedirectToPage("Page2", new { userName = UserName });
            }

  

            return Page();
        }
    }
}
