using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.Query2
{
    public class Page2Model : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        public void OnGet()
        {
            // UserName is automatically bound from the query parameter because of the [BindProperty(SupportsGet = true)] attribute
        }
    }
}
