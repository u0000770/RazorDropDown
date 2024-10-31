using DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorDropDown.Pages.V4
{

        public class IndexPostModel : PageModel
        {
            [BindProperty]
            public string SelectId { get; set; }

            [BindProperty]
            public SelectViewModel VM { get; set; } = new SelectViewModel();

            public ActionResult OnGet()
            {
                // Initialize ViewModel with list
                VM = new SelectViewModel
                {
                    List = SelectViewModel.BuildList()
                };

                return Page();
            }

            public ActionResult OnPost()
            {
                // Process the posted SelectId and populate the ViewModel
                VM = new SelectViewModel
                {
                    List = SelectViewModel.BuildList(),
                    SelectId = SelectId
                };

                // Render the page with the updated ViewModel after post
                return Page();
            }
        }

    }

