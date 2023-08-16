using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public interface ICourseRepository
    {
        Task<List<CourseModel>> GetCourses();
        Task<CourseModel> GetCourseById(int id);    
        Task<CourseModel> GetCourseByName(string name);
        Task<CourseModel> AddCourse(CourseModel course);
        Task<CourseModel> UpdateCourse(int CourseId, CourseModel course);
        Task<CourseModel> DeleteCourse(int CourseId);

    }
}
