using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Cookie
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
            // Set the cookie with the user's name
            if (!string.IsNullOrEmpty(UserName))
            {
                Response.Cookies.Append("UserName", UserName, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddMinutes(10) // Cookie expires in 10 minutes
                });
            }

            return RedirectToPage("Page2");
        }
    }
}
