using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Department
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeDepartment> Departments { get; set; }
    }
}
