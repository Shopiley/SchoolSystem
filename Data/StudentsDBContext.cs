using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Data
{
    public class StudentsDBContext : DbContext      // to be injected into the services of the solution
    {

        //constructor for the class
        public StudentsDBContext(DbContextOptions options) : base(options)
        {
        }

        //Propeties which will act as tables
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
