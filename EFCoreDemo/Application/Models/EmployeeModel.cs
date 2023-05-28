namespace Application.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid GradeId { get; set; }

        public Guid AddressId { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
    }
}
