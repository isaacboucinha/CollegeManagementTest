using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeManagementTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CollegeManagementTest.Models.DTO;

namespace CollegeManagementTest.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {

        private readonly ILogger<WeatherForecastController> logger;
        private readonly CollegeManagementContext context;

        public StudentsController(CollegeManagementContext context, ILogger<WeatherForecastController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpPost("{id}")]
        public Student CreateStudent(long id)
        {
            return context.Student.First();
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
            return context.Student.Find(id);
        }

        [HttpPut("{id}")]
        public Student Update()
        {
            return context.Student.First();
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            context.Student.Remove(context.Student.Find(id));
            return false;
        }
    }
}