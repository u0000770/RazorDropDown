using System.ComponentModel.DataAnnotations;
using static System.Formats.Asn1.AsnWriter;

namespace RazorDropDown.Domain
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string Description { get; set; }
        public virtual List<Shop> Shop { get; set; }
    }
}
