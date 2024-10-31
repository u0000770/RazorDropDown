using DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.V4
{
    public class IndexModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public string SelectId { get; set; }

        [BindProperty]
        public SelectViewModel VM { get; set; } = new SelectViewModel();

        public ActionResult OnGet()
        {
            // Create a model object of SelectViewModel with a populated list
            VM = new SelectViewModel
            {
                List = SelectViewModel.BuildList()
            };

            return Page();
        }

        public ActionResult OnGetDetails()
        {
            // Create a model object of SelectViewModel with the populated SelectId and list
            VM = new SelectViewModel
            {
                List = SelectViewModel.BuildList(),
                SelectId = SelectId
            };

            // Render the page with the updated ViewModel
            return Page();
        }
    }
}
