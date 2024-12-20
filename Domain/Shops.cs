﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace RazorDropDown.Domain
{
    public class Shop
    {
        [Key]
        public int StoreId { get; set; }
        public int StoreNumber { get; set; }
        public required string StoreName { get; set; }
        public required string Description { get; set; }
        public int GradeId { get; set; }
        public Grade? Grade { get; set; }
    }
}
