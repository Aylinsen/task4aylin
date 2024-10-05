namespace BLL.DAL.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal GPA { get; set; }
}