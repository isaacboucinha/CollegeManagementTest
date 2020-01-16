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
    public class SubjectsController : Controller
    {

        private readonly ILogger<SubjectsController> logger;
        private readonly CollegeManagementContext context;

        public SubjectsController(CollegeManagementContext context, ILogger<SubjectsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpPost("{id}")]
        public Subject CreateSubject(SubjectDTO student)
        {

            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Subject UpdateSubject(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public bool DeleteSubject(long id)
        {
            throw new NotImplementedException();
        }
    }
}