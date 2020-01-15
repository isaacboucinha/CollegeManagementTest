using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models.DTO
{
    public class CourseDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<SubjectDTO> Subjects { get; set; }

        public IEnumerable<TeacherDTO> Teachers { get; set; }

        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
