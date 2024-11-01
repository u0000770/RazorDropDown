using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.TempData
{
    public class Page2Model : PageModel
    {
        public void OnGet()
        {
            var userName = TempData["UserName"];
            TempData["UserNameBack"] = userName;
        }
    }
}
