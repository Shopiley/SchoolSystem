using System.Collections.Generic;

namespace SchoolSystem.Data
{
    public class Student
    {
            public int Id { get; set; }
            public string Firstname { get; set; }
            public string Lastname { get; set; }  
            public string Gender { get; set; }
            public List<Course> Courses { get; set; } = new();

    }
}
