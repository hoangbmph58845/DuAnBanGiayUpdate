namespace BaiTapLab_2.Models
{
    public class Lop
    {
        public int Id { get; set; }
        public string LopName { get; set; }
        public string? Description { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
