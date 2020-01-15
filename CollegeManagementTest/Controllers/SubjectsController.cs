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
    public class SubjectsController : Controller
    {

        private readonly ILogger<WeatherForecastController> logger;
        private readonly CollegeManagementContext context;

        public SubjectsController(CollegeManagementContext context, ILogger<WeatherForecastController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpPost("{id}")]
        public Subject CreateSubject(SubjectDTO student)
        {

            return context.Subject.First();
        }

        [HttpGet("")]
        public IEnumerable<SubjectDTO> GetSubjects()
        {
            logger.LogInformation("----- Accessed GetSubjects -----");

            var res = from subject in context.Subject
                      select new SubjectDTO
                      {
                          Name = subject.Name,
                          Teacher = new TeacherDTO
                          {
                              Name = subject.Teacher.Name,
                              Salary = subject.Teacher.Salary,
                              Birthday = subject.Teacher.Birthday
                          },
                          Grades = from grade in context.Grade
                                   where grade.Subject.Id == subject.Id
                                   select new GradeDTO
                                   {
                                       Value = grade.Value,
                                       Student = new StudentDTO
                                       {
                                           Name = grade.Student.Name
                                       }
                                   }
                      };

            return res;
        }

        [HttpGet("{id}")]
        public Subject GetSubject(long id)
        {
            return context.Subject.Find(id);
        }

        [HttpPut("{id}")]
        public Subject Update()
        {
            return context.Subject.First();
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            context.Subject.Remove(context.Subject.Find(id));
            return false;
        }
    }
}