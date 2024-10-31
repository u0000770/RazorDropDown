using DropDown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDropDown.Data;

namespace RazorDropDown.Pages.V6
{
    public class IndexModel : PageModel
    {
        private readonly OurDbContext _context;

        [BindProperty]
        public string SelectedGradeId { get; set; }

        [BindProperty]
        public GradeStoreVM VM { get; set; } = new GradeStoreVM();

        public IndexModel(OurDbContext context)
        {
            _context = context;

        }

        public ActionResult OnGet()
        {
            var grades = _context.Grades.ToList();
            // create a GradeStoreVM object
            VM.List = GradeStoreVM.BuildList(grades);
            // pass a populated model to the view
            return Page();
        }

        public ActionResult OnPost()
        {
            var grades = _context.Grades.ToList();
            // cast the selection into a int

            var gid = Convert.ToInt64(SelectedGradeId);
            // get the stores associated with a grade
            var stores = _context.Shops.Where(x => x.GradeId == gid).ToList();
            // construct a viewmodel
            VM.List = GradeStoreVM.BuildList(grades);
            VM.GradeStores = stores;
            // return the viewmodel
            return Page();
        }
    }
}
