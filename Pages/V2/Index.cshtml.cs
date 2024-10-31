using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorDropDown.Pages.V2
{
    public class IndexModel : PageModel
    {
        public ActionResult OnGet()
        {
            // Build a list of SelectListItems
            List<SelectListItem> items = BuildItems();
            // Put our list of items in the ViewBag
            ViewData["Grade"] = items;
            // dig out and present Master2 View
            return Page();
        }

       

        private static List<SelectListItem> BuildItems()
        {
            // Create a SelectListItem list
            List<SelectListItem> items = new List<SelectListItem>();
            // Add 4 options to our list of items 
            items.Add(new SelectListItem { Text = "Very Large", Value = "0" });
            items.Add(new SelectListItem { Text = "Large", Value = "1" });
            items.Add(new SelectListItem { Text = "Medium", Value = "2" });
            items.Add(new SelectListItem { Text = "Small", Value = "3" });
            return items;
        }

        




    }
}
