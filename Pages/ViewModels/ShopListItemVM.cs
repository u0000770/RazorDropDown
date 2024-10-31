using RazorDropDown.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DropDown.Models
{

    public class ShopItemViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? StoreId { get; set; }
        
        [Required]
        [Display(Name = "Number")]
        public int StoreNumber { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string StoreName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Grade")]
        public int GradeId { get; set; }
        public SelectList? listOfGrades { get; set; }

        public static SelectList BuildGradeSelectList(List<Grade> grades,int? Id = null )
        {
            if (Id == null)
            {
                return new SelectList(grades, "GradeId", "Description");
            }
            return new SelectList(grades, "GradeId", "Description", Id);
        }
    }


    public class ShopListItemVM
    {
        [HiddenInput(DisplayValue = false)]
        public int StoreId { get; set; }
        [Display(Name ="Store Name")]
        public string StoreName { get; set; }
        [Display(Name = "Grade")]
        public string grade { get; set; }
    }

    public class ShopListDetailVM : ShopListItemVM
    {
        [Display(Name = "Store Number")]
        public int StoreNumber { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
