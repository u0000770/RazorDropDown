using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDropDown.Data;
using RazorDropDown.Domain;

namespace RazorDropDown.Pages.S2
{
    
    public class IndexModel : PageModel
    {

        private readonly OurDbContext _context;

        [BindProperty]
        public List<Shop> Shops { get; set; } = new List<Shop>();

        public IndexModel(OurDbContext context)
        {
            _context = context;

        }


        public ActionResult OnGet()
        {
            Shops = _context.Shops.ToList();
            return Page();
        }
    }
}
