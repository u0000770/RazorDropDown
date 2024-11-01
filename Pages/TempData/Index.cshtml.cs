using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.TempData
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                TempData["UserName"] = UserName; // Store UserName in TempData
                return RedirectToPage("Page2");  // Redirect to Page2
            }
            return Page();
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
