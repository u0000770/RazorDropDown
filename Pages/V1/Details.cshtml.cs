using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.V1
{
    public class DetailsModel : PageModel
    {
        public ActionResult OnGet()
        {
            // Read the query string with the name "Grade"
            string choice = HttpContext.Request.Query["Grade"];
            // Put the choice into the ViewBag and display in its own view
            ViewData["choce"] = choice;
            return Page();
        }
    }
}
