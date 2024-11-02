using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Query1
{
    public class Page2Model : PageModel
    {
        public string? UserName { get; set; }

        public void OnGet(string userName)
        {
            UserName = userName; // Set UserName to the value from the query string parameter
        }
    }
}

