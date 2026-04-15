namespace LamDeThiThu2.Models
{
    public class Role
    {
            public int Id { get; set; }
            public string? NameRole { get; set; }
            public string? Description { get; set; }
            public ICollection<Employee>? Employees { get; set; }
        }
    }



