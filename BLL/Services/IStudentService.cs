using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentModel>> Query();
        Task<StudentModel> Create(StudentModel student);
        Task<StudentModel> Update(StudentModel student);
        Task<bool> Delete(int id);
    }
}