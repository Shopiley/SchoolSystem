using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class EnrollmentModel
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public string CourseId { get; set; }
    }
}
