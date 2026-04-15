namespace BaiTapLab_2.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string MaSV { get; set; }
        public DateTime DOB { get; set; }

        public int LopId { get; set; }  // 1 học sinh - 1 lớp
        public Lop Lop { get; set; }
        public ICollection<MonHoc> MonHocs { get; set; } = new List<MonHoc>();  // 1 học sinh có thể học nhiều môn
    }
}
