using Application.Models;

namespace Application;

public interface IEmployeeRepository
{
    EmployeeViewModel Get(Guid id);

    EmployeeViewModel GetFull(Guid id);

    int Insert(EmployeeModel model);

    int AddDepartments(Guid employeeId, List<Guid> departmentIds);

    int Update(EmployeeModel model);

    int Delete(Guid id);

    int RemoveDepartments(Guid employeeId, List<Guid> departmentIds);
}