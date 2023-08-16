using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolSystem.Data;
using SchoolSystem.Models;
using SchoolSystem.Repository;

namespace SchoolSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }



        [HttpGet("")]
        public async Task<IActionResult> GetStudents()
        {

            var student = await _studentRepository.GetStudents();

            return Ok(student);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewStudent([FromBody] StudentModel addStudentModel)
        {
            if (ModelState.IsValid)
            {
                var NewStudent = await _studentRepository.AddStudent(addStudentModel);

                return Ok(NewStudent);
            }

            else
            {
                return BadRequest(ModelState);
            }
        }
    }
} 
