using System.ComponentModel.DataAnnotations;

namespace Baithuchanh01.Dtos
{
    public class UpdateProductDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;


        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }


        [Range(0, int.MaxValue)]
        public int Stock { get; set; } = 0;


        [Required]
        public int CategoryId { get; set; }
    }
}
