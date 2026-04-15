using System.ComponentModel.DataAnnotations;

namespace LamDeThiThu2.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string NameEmp { get; set; }

        [Required]
        public string DiaChi { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required, EmailAddress]
        public string Mail { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
    }
}