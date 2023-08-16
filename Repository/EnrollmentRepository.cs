using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Migrations;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly StudentsDBContext dbContext;
        private readonly IMapper mapper;

        public EnrollmentRepository(StudentsDBContext dbContext, IMapper mapper) {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<bool> IsStudentEnrolledInMoreThanThreeCourses(int studentId)
        {
            var student = await dbContext.Students
                                        .Include(s => s.Courses)
                                        .FirstOrDefaultAsync(s => s.Id == studentId);

            return student.Courses.Count == 3;
        }

        public async Task<bool> DoesStudentExist(int studentId)
        {
            var student = await dbContext.Students.FindAsync(studentId);

            if (student == null) {
                return false;
            }
            return true;
        }

        public async Task<bool> DoesCourseExist(string courseId)
        {
            var course = await dbContext.Courses.FindAsync(courseId);

            if (course == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsEnrolled(EnrollmentModel enrollment)
        {
            var student = await dbContext.Students
                            .Include(s => s.Courses)
                            .FirstOrDefaultAsync(s => s.Id == enrollment.StudentId);

            var courseExists = student.Courses.Any(sc => sc.CourseId == enrollment.CourseId);

            return courseExists;

        }

        public async Task<string> EnrollCourse(EnrollmentModel enrollment)
        {
            var student = await dbContext.Students.FindAsync(enrollment.StudentId);
            var course = await dbContext.Courses.FindAsync(enrollment.CourseId);
            student.Courses.Add(course);

            await dbContext.SaveChangesAsync();

            return $"Student {student.Id} successfully enrolled to course {course.CourseName}";
        }


        public async Task<string> UnenrollCourse(EnrollmentModel model)
        {
            var student = await dbContext.Students
                .Include(s => s.Courses)
                .FirstOrDefaultAsync(s => s.Id == model.StudentId);

            var course = await dbContext.Courses.FindAsync(model.CourseId);
                student.Courses.Remove(course);
                await dbContext.SaveChangesAsync();

            return $"Student {student.Id} successfully unenrolled from course {course.CourseName}";

        }

    }
}

