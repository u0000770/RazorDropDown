using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Cookie
{
    public class Page2Model : PageModel
    {
        public string UserName { get; set; }

        public void OnGet()
        {
            // Read the cookie value
            if (Request.Cookies.TryGetValue("UserName", out var userName))
            {
                UserName = userName;
            }
        }
    }
}
