using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid GradeId { get; set; }

        public Grade Grade { get; set; }

        public Guid AddressId { get; set; }

        public Address Address { get; set; }

        public ICollection<EmployeeDepartment> Departments { get; set; }
    }
}
