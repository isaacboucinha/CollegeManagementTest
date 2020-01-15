using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models
{
    public class Teacher
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
