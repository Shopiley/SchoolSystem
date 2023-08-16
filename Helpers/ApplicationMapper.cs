using AutoMapper;
using SchoolSystem.Controllers;
using SchoolSystem.Data;
using SchoolSystem.Models;

namespace SchoolSystem.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Student, StudentModel>().ReverseMap();
           // .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.CourseStudent.Select(sc => sc.Course.CourseName).ToList()));
            CreateMap<Course, CourseModel>().ReverseMap();
    

        }
    }
}
