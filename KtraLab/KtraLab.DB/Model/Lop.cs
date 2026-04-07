namespace KtraLab.DB.Model
{
    public class Lop
    {
        public int Id { get; set; }
        public string LopName { get; set; }
        public string Description { get; set; }

        public List<Student> Students { get; set; }
    }
}
