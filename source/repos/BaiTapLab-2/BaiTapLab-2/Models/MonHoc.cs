namespace BaiTapLab_2.Models
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public string? Description { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
