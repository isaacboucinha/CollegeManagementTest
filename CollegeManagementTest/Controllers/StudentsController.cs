using System;
using System.Collections.Generic;
using System.Linq;
using CollegeManagementTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CollegeManagementTest.Models.DTO;

namespace CollegeManagementTest.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly ILogger<StudentsController> logger;
        private readonly CollegeManagementContext context;

        public StudentsController(CollegeManagementContext context, ILogger<StudentsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpPost("{id}")]
        public Student CreateStudent(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("")]
        public IEnumerable<StudentDTO> GetStudents()
        {
            logger.LogInformation("----- Accessed GetStudents -----");

            var res = from student in context.Student
                      select new StudentDTO
                      {
                          Name = student.Name,
                          Birthday = student.Birthday,
                          RegistrationNumber = student.RegistrationNumber,
                          Grades = from grade in student.Grades
                                   select new GradeDTO
                                   {
                                       Value = grade.Value,
                                       Subject = new SubjectDTO
                                       {
                                           Name = grade.Subject.Name
                                       }
                                   }
                      };

            return res;
        }

        [HttpGet("{id}")]
        public Student GetStudent(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Student UpdateStudent(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public bool DeleteStudent(long id)
        {
            throw new NotImplementedException();
        }
    }
}