namespace KtraLab.DB.Model
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public string Description { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
