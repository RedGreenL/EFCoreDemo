using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Grade
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
