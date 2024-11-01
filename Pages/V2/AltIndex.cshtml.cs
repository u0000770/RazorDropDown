using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorDropDown.Domain;

namespace RazorDropDown.Pages.V2
{
    public class AltIndexModel : PageModel
    {
        public ActionResult OnGet()
        {
            // creates a SelectList of grade Items that is used to populate a dropdown 
            ViewData["GradeId"] = new SelectList(BuildItems(), "GradeId", "Description");
            

            return Page();
        }



        private static List<Grade> BuildItems()
        {
            // Create  a List of Grades
            List<Grade> items = new List<Grade>();
            // Add 4 grades to our list of items 
            items.Add(new Grade {  GradeId = 1, Description= "Small" });
            items.Add(new Grade {  GradeId = 2, Description = "Medium" });
            items.Add(new Grade { GradeId = 3, Description = "Large" });
            items.Add(new Grade { GradeId = 4, Description = "Very Large" });
            return items;
        }
    }
}
