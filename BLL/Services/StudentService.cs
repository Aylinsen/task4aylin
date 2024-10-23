using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DAL;
using BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentsDbContext _context;

        public StudentService(StudentsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentModel>> Query()
        {
            var students = await _context.Students.ToListAsync();
            return students.ConvertAll(s => new StudentModel
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                BirthDate = s.BirthDate,
                GPA = s.GPA
            });
        }

        public async Task<StudentModel> Create(StudentModel student)
        {
            var entity = new BLL.DAL.Entities.Student
            {
                Name = student.Name,
                Surname = student.Surname,
                BirthDate = student.BirthDate,
                GPA = student.GPA
            };
            _context.Students.Add(entity);
            await _context.SaveChangesAsync();

            student.Id = entity.Id;
            return student;
        }

        public async Task<StudentModel> Update(StudentModel student)
        {
            var entity = await _context.Students.FindAsync(student.Id);
            if (entity == null) return null;

            entity.Name = student.Name;
            entity.Surname = student.Surname;
            entity.BirthDate = student.BirthDate;
            entity.GPA = student.GPA;

            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Students.FindAsync(id);
            if (entity == null) return false;

            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
