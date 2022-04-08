using System.ComponentModel.DataAnnotations;

namespace Demo1Api.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximum 50 Characters")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Maximum 250 Characters")]
        public string Description { get; set; }
    }
}
