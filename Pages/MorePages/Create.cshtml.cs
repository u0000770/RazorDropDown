using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorDropDown.Data;
using RazorDropDown.Domain;

namespace RazorDropDown.Pages.MorePages
{
    public class CreateModel : PageModel
    {
        private readonly RazorDropDown.Data.OurDbContext _context;

        public CreateModel(RazorDropDown.Data.OurDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "GradeId");
            return Page();
        }

        [BindProperty]
        public Shop Shop { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shops.Add(Shop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
