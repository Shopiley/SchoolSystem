using SchoolSystem.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class StudentModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        public string Gender { get; set; }

        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();

    }
}
