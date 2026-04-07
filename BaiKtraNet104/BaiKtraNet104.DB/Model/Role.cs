using System.ComponentModel.DataAnnotations;

namespace BaiKtraNet104.DB.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
          
        public string NameRole { get; set; }
        public string Description { get; set; }
        

    }
}
