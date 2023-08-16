using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace SchoolSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsDBContext dbContext;
        private readonly IMapper mapper;

        public StudentRepository(StudentsDBContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<List<StudentModel>> GetStudents()
        {
            var students = await dbContext.Students.Include(p=>p.Courses).ToListAsync();
            return mapper.Map<List<StudentModel>>(students);
        }

        public async Task<StudentModel> AddStudent(StudentModel addStudentModel)
        {
            var student = new Student()
            {
                //Id = Guid.NewGuid(),
                Firstname = addStudentModel.Firstname,
                Lastname = addStudentModel.Lastname,
                Gender = addStudentModel.Gender
            };

            await dbContext.Students.AddAsync(student);

            await dbContext.SaveChangesAsync();

            return mapper.Map<StudentModel>(student);

        }

        public async Task<StudentModel> GetStudentByID(int studentId)
        {
            var student = await dbContext.Students.FindAsync(studentId);
            return mapper.Map<StudentModel>(student);
        }
        Task IStudentRepository.DeleteStudent(int studentID)
        {
            throw new System.NotImplementedException();
        }

        public async Task<StudentModel> UpdateStudent(int studentId, Student updateStudentModel)
        {
            var student = await dbContext.Students.FindAsync(studentId);
            if (student != null)
            {
                student.Firstname = updateStudentModel.Firstname;
                student.Lastname = updateStudentModel.Lastname;
                student.Gender = updateStudentModel.Gender;

                await dbContext.SaveChangesAsync();
            };

            return mapper.Map<StudentModel>(student);

        }

        Task IStudentRepository.Save()
        {
            throw new System.NotImplementedException();
        }
    }
}


