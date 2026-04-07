using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKtraNet104.DB.Model
{
    public class Employee
    {
        public int ID { get; set; }
  
        public string NameEmp { get; set; }
        public string DiaChi { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
