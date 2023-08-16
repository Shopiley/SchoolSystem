using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class CourseModel
    {
        [Required]
        public string CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }
    }
}
