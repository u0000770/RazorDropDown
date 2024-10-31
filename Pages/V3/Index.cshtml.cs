using DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.V3
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public SelectViewModel VM { get; set; } = new SelectViewModel();


        public ActionResult OnGet()
        {
            // create and assign a populated SelectViewModel to VM
            VM = new SelectViewModel
            {
                List = SelectViewModel.BuildList()
            };

            return Page();
        }
    }
}
