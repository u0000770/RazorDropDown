using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDropDown.Data;
using RazorDropDown.Domain;

namespace RazorDropDown.Pages.S1
{
    public class EditModel : PageModel
    {
        private readonly OurDbContext _context;

        public EditModel(OurDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Shop Shop { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops.FirstOrDefaultAsync(m => m.StoreId == id);
            if (shop == null)
            {
                return NotFound();
            }
            Shop = shop;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            _context.Attach(Shop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
             throw;
            }

            return RedirectToPage("./Index");
        }

        private bool GuestExists(int id)
        {
            return _context.Shops.Any(e => e.StoreId == id);
        }
    }
}
