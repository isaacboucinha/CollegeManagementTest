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
    public class CoursesController : Controller
    {

        private readonly ILogger<WeatherForecastController> logger;
        private readonly CollegeManagementContext context;

        public CoursesController(CollegeManagementContext context, ILogger<WeatherForecastController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpPost("{id}")]
        public Course CreateCourse(long id)
        {
            return context.Course.First();
        }

        [HttpGet("")]
        public IEnumerable<CourseDTO> GetCourses()
        {
            logger.LogInformation("----- Accessed GetCourses -----");

            var res = from course in context.Course
                      select new CourseDTO
                      {
                          Id = course.Id,
                          Name = course.Name,
                          Subjects = from subject in context.Subject
                                     join courseSubject in context.CourseSubjects
                                     on subject.Id equals courseSubject.Subject.Id
                                     where courseSubject.Course.Id == course.Id
                                     select new SubjectDTO
                                     {
                                         Name = subject.Name,
                                         Teacher = new TeacherDTO
                                         {
                                             Name = subject.Teacher.Name
                                         }
                                     },
                          Students = (from student in context.Student
                                      join grade in context.Grade
                                      on student.Id equals grade.Student.Id
                                      join subject in context.Subject
                                      on grade.Subject.Id equals subject.Id
                                      join courseSubject in context.CourseSubjects
                                      on subject.Id equals courseSubject.Subject.Id
                                      where courseSubject.Course.Id == course.Id &&
                                         //select all students that are not part of this course
                                         !(from student in context.Student
                                           join grade in context.Grade
                                           on student.Id equals grade.Student.Id
                                           join subject in context.Subject
                                           on grade.Subject.Id equals subject.Id
                                           join courseSubject in context.CourseSubjects
                                           on subject.Id equals courseSubject.Subject.Id
                                           where
                                           //select all subject not in course
                                           (from subject in context.Subject
                                            join courseSubject in context.CourseSubjects
                                            on subject.Id equals courseSubject.Subject.Id
                                            where
                                                //select all subjects in course
                                                !(from subject in context.Subject
                                                  join courseSubject in context.CourseSubjects
                                                  on subject.Id equals courseSubject.Subject.Id
                                                  where courseSubject.Course.Id == course.Id
                                                  select subject.Id
                                                ).Contains(subject.Id)
                                            select subject.Id
                                            ).Contains(subject.Id)
                                           select student.Id
                                          ).Distinct().Contains(student.Id)

                                      let averageGrade = student.Grades.Select(grade => grade.Value).Average()
                                      select new StudentDTO
                                      {
                                          Birthday = student.Birthday,
                                          RegistrationNumber = student.RegistrationNumber,
                                          Name = student.Name,
                                          GradeAverage = averageGrade
                                      }
                                      )
                      };

            //for some reason i couldn't get distinct to work in the query above, so
            //i just distinct here
            var resList = res.ToList();
            foreach(var course in resList)
            {
                if(course.Students != null)
                {
                    course.Students = course.Students.Distinct();
                }
            }
            return resList;
        }

        [HttpGet("{id}")]
        public Course GetCourse(long id)
        {
            return context.Course.Find(id);
        }

        [HttpPut("{id}")]
        public Course Update()
        {
            return context.Course.First();
        }

        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            context.Course.Remove(context.Course.Find(id));
            return false;
        }
    }
}