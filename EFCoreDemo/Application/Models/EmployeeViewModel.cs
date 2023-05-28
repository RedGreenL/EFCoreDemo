namespace Application.Models;

public class EmployeeViewModel
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Grade { get; set; }

    public List<string> Departments { get; set; }

    public string Street { get; set; }

    public string City { get; set; }
}