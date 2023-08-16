using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models;
using SchoolSystem.Repository;

namespace SchoolSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPost("/enroll")]
        public async Task<IActionResult> Enroll([FromBody] EnrollmentModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _enrollmentRepository.DoesStudentExist(model.StudentId) == false)
                {
                    return NotFound($"Student with Student ID {model.StudentId} does not exist");
                }

                if (await _enrollmentRepository.DoesCourseExist(model.CourseId) == false)
                {
                    return NotFound($"Course with Course Code {model.CourseId} does not exist");
                }

                if (await _enrollmentRepository.IsEnrolled(model) == true)
                {
                    return BadRequest("Student is already assigned to this course.");
                }

                if (await _enrollmentRepository.IsStudentEnrolledInMoreThanThreeCourses(model.StudentId))
                {
                    return BadRequest("Student cannot be enrolled in more than three(3) courses.");
                }

                var response = await _enrollmentRepository.EnrollCourse(model);
                return Ok(response);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPatch("/unenroll")]
        public async Task<IActionResult> Unenroll([FromBody] EnrollmentModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _enrollmentRepository.DoesStudentExist(model.StudentId) == false)
                {
                    return NotFound($"Student with Student ID {model.StudentId} does not exist");
                }

                if (await _enrollmentRepository.DoesCourseExist(model.CourseId) == false)
                {
                    return NotFound($"Course with Course Code {model.CourseId} does not exist");
                }

                if (await _enrollmentRepository.IsEnrolled(model) == false)
                {
                    return BadRequest("Cannot unenroll student. Student has not been assigned to this course.");
                }

                var response = await _enrollmentRepository.UnenrollCourse(model);
                return Ok(response);
            }
            
            else { return BadRequest(ModelState); }
        }
    }
}
