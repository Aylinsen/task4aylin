namespace BLL.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal GPA { get; set; }

        // StudentModel'i Student entity'sine dönüştüren metod
        public BLL.DAL.Entities.Student ToEntity()
        {
            return new BLL.DAL.Entities.Student
            {
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
                BirthDate = this.BirthDate,
                GPA = this.GPA
            };
        }

        // Student entity'sinden StudentModel'e dönüştüren metod
        public static StudentModel FromEntity(BLL.DAL.Entities.Student student)
        {
            return new StudentModel
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                BirthDate = student.BirthDate,
                GPA = student.GPA
            };
        }
    }
}