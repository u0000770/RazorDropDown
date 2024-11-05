using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDropDown.Data;
using RazorDropDown.Domain;

namespace RazorDropDown.Pages.MorePages
{
    public class DetailsModel : PageModel
    {
        private readonly RazorDropDown.Data.OurDbContext _context;

        public DetailsModel(RazorDropDown.Data.OurDbContext context)
        {
            _context = context;
        }

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
            else
            {
                Shop = shop;
            }
            return Page();
        }
    }
}
