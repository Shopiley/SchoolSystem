using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Data
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }

        public string CourseName { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
