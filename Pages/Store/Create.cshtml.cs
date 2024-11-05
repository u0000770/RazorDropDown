using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorDropDown.Data;
using RazorDropDown.Domain;

namespace RazorDropDown.Pages.Store
{
    public class CreateModel : PageModel
    {
        private readonly RazorDropDown.Data.OurDbContext _context;

        public CreateModel(RazorDropDown.Data.OurDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Grab any data ( if needed )
        /// Prepare the form to Display that data
        /// Invoke the display of the form
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGetAsync()
        {
            // get the grades
            var grades = _context.Grades; 
            // the list of items, key to be GradeId, Display Description
            var slist = new SelectList(grades, "GradeId", "Description");
            // Set up the select list to be avaialable to the ux via the ViewData
            ViewData["GradeId"] = slist;
            // rednder create.chtml
            return Page();
        }

        [BindProperty]
        public Shop Shop { get; set; } = default!;

        /// <summary>
        /// Read the bound data [BindProperty]
        /// Validates the model
        /// Add to the EF collection
        /// save the data to the dtabase
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            // Remove Grade from ModelState validation
            ModelState.Remove("Shop.Grade");

            if (!ModelState.IsValid)
            {
                return Page();
            }
            // attatching this object to th collection of objects via EF
            _context.Shops.Add(Shop);
            // executes the sql ( Insert blah blah )
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
