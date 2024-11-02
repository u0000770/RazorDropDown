using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDropDown.Data;
using RazorDropDown.Domain;

namespace RazorDropDown.Pages.Store
{
    public class IndexModel : PageModel
    {
        private readonly RazorDropDown.Data.OurDbContext _context;

        public IndexModel(RazorDropDown.Data.OurDbContext context)
        {
            _context = context;
        }

        public IList<Shop> Shop { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    Shop = await _context.Shops
        //        .Include(s => s.Grade).ToListAsync();
        //}

        /// <summary>
        /// More Explicite and Conventional
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync()
        {
            Shop = await _context.Shops
                .Include(s => s.Grade)
                .ToListAsync();

            return Page();
        }
    }
}
