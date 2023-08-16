using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public interface IStudentRepository
    {
        Task<List<StudentModel>> GetStudents();
        Task<StudentModel> GetStudentByID(int studentId);
        Task<StudentModel> AddStudent(StudentModel studentModel);
        Task DeleteStudent(int studentID);
        Task<StudentModel> UpdateStudent(int studentId, Student updateStudentModel);
        Task Save();
    }
}
