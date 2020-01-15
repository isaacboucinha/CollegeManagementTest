using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementTest.Models
{
    public class Grade
    {
        public long Id { get; set; }
        public int Value { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; } 
    }
}
