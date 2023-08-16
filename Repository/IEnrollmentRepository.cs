using System.Threading.Tasks;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public interface IEnrollmentRepository
    {
        Task<string> EnrollCourse(EnrollmentModel model);
        Task<string> UnenrollCourse(EnrollmentModel model);
        Task<bool> DoesStudentExist(int studentId);

        Task<bool> DoesCourseExist(string courseId);
        Task<bool> IsEnrolled(EnrollmentModel model);
        Task<bool> IsStudentEnrolledInMoreThanThreeCourses(int studentId);
    }
}
