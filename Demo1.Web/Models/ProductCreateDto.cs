using System.ComponentModel.DataAnnotations;

namespace Demo1.Web.Models
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 Characters")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Maximum 500 Characters")]
        public string Description { get; set; }
    }
}