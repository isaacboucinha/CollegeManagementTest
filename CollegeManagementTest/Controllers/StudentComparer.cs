using CollegeManagementTest.Models;
using CollegeManagementTest.Models.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CollegeManagementTest.Controllers
{
    internal class StudentComparer : IEqualityComparer<StudentDTO>
    {
        public bool Equals([AllowNull] StudentDTO x, [AllowNull] StudentDTO y)
        {
            return x == null && y == null || (x != null && y != null &&
                                                x.Name == y.Name &&
                                                x.RegistrationNumber == y.RegistrationNumber);
        }

        public int GetHashCode([DisallowNull] StudentDTO obj)
        {
            return HashCode.Combine(obj.Name, obj.RegistrationNumber);
        }
    }
}