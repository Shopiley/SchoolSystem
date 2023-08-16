using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentsDBContext dbContext;
        private readonly IMapper mapper;

        public CourseRepository(StudentsDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<CourseModel>> GetCourses()
        {
            var courses = await dbContext.Courses.ToListAsync();
            return mapper.Map<List<CourseModel>>(courses);
        }
        public async Task<CourseModel> AddCourse(CourseModel addCourseModel)
        {
            var course = new Course()
            {
                CourseId = addCourseModel.CourseId,
                CourseName = addCourseModel.CourseName
            };

            await dbContext.Courses.AddAsync(course);

            await dbContext.SaveChangesAsync();

            return mapper.Map<CourseModel>(course);
        }

        public Task<CourseModel> DeleteCourse(int CourseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CourseModel> GetCourseById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CourseModel> GetCourseByName(string name)
        {
            throw new System.NotImplementedException();
        }

        

        public Task<CourseModel> UpdateCourse(int CourseId, CourseModel course)
        {
            throw new System.NotImplementedException();
        }
    }
}
