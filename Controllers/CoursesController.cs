using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models;
using SchoolSystem.Repository;

namespace SchoolSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
       private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetCourses()
        {
            var course = await _courseRepository.GetCourses();

            return Ok(course);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewCourse([FromBody] CourseModel addCourseModel)
        {
            if (ModelState.IsValid)
            {
                var NewCourse = await _courseRepository.AddCourse(addCourseModel);

                return Ok(NewCourse);
            }

            else
            {
                return BadRequest(ModelState);
            }
           
        }
    }
}
