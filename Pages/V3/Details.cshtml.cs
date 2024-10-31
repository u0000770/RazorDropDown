using DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.V3
{
    public class DetailsModel : PageModel
    {

        [BindProperty]
        public SelectViewModel VM { get; set; } = default!;

        public ActionResult OnGet()
        {

            // create a model object of SelectViewModel with a populated SelectId
            var model = new SelectViewModel
            {
                SelectId = VM.SelectId
            };
            // dig out and present Detail3 View
            return Page();
        }
    }
}
