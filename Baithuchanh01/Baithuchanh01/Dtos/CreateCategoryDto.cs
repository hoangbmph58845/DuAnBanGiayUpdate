using System.ComponentModel.DataAnnotations;

namespace Baithuchanh01.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;


        [MaxLength(255)]
        public string? Description { get; set; }
    }
}
