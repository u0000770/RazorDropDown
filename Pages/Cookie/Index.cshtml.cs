using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Cookie
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }

        public void OnGet()
        {
            // Check if the cookie exists and retrieve its value
            if (Request.Cookies.TryGetValue("UserName", out var userName))
            {
                ViewData["UserName"] = userName; // Set the cookie value in ViewData for display
            }
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
