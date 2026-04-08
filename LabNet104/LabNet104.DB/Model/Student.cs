namespace LabNet104.DB.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string MaSV { get; set; }
        public DateTime DOB { get; set; }

        public int LopId { get; set; }
        public Lop Lop { get; set; }

        // Quan hệ nhiều-nhiều với Môn học
        public List<MonHoc> MonHocs { get; set; } = new();
    }
}
