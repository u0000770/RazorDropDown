using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.V2
{
    public class DetailsModel : PageModel
    {
      
        public ActionResult OnGet(string Grade)
        {
            // read the input parameter passed back from the view
            string choice = Grade;
            // updage the viewbag
            ViewData["Grade"] = choice;
            // open up the view to display the selection
            return Page();
        }
    }
}
