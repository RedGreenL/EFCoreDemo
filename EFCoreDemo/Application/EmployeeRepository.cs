using Application.Models;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeViewModel Get(Guid id)
        {
            using var db = new EFCoreDbContext();
            var entity = db.Employees.First(x => x.Id == id);

            return new EmployeeViewModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
        }

        public EmployeeViewModel GetFull(Guid id)
        {
            using var db = new EFCoreDbContext();
            var entity = db.Employees
                .Include(x => x.Address)
                .Include(x => x.Grade)
                .Include(x => x.Departments)
                .ThenInclude(x => x.Department)
                .First(x => x.Id == id);

            return new EmployeeViewModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                City = entity.Address.City,
                Street = entity.Address.Street,
                Grade = entity.Grade.Name,
                Departments = entity.Departments.Select(x => x.Department.Name).ToList()
            };
        }

        public int Insert(EmployeeModel model)
        {
            using var db = new EFCoreDbContext();

            var address = new Address
            {
                Id = Guid.NewGuid(),
                City = model.City,
                Street = model.Street
            };

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                LastName = model.LastName,
                FirstName = model.FirstName,
                GradeId = model.GradeId,
                AddressId = address.Id
            };

            db.Addresses.Add(address);
            db.Employees.Add(employee);

            return db.SaveChanges();
        }

        public int AddDepartments(Guid employeeId, List<Guid> departmentIds)
        {
            using var db = new EFCoreDbContext();

            // foreach
            var entities = departmentIds.Select(departmentId => new EmployeeDepartment
            {
                EmployeeId = employeeId,
                DepartmentId = departmentId
            });

            db.EmployeeDepartment.AddRange(entities);

            return db.SaveChanges();
        }

        public int Update(EmployeeModel model)
        {
            using var db = new EFCoreDbContext();

            var employee = db.Employees.FirstOrDefault(x => x.Id == model.Id) 
                                 ?? throw new NullReferenceException();

            var address = db.Addresses.FirstOrDefault(x => x.Id == model.Id)
                           ?? throw new NullReferenceException();

            employee.LastName = model.LastName;
            employee.FirstName = model.FirstName;
            employee.GradeId = model.GradeId;
            employee.AddressId = address.Id;

            address.City = model.City;
            address.Street = model.Street;

            db.Addresses.Update(address);
            db.Employees.Update(employee);

            return db.SaveChanges();
        }

        public int Delete(Guid id)
        {
            using var db = new EFCoreDbContext();
            var entity = db.Employees.First(x => x.Id == id);

            db.Employees.Remove(entity);
            return db.SaveChanges();
        }

        public int RemoveDepartments(Guid employeeId, List<Guid> departmentIds)
        {
            using var db = new EFCoreDbContext();

            foreach (var departmentId in departmentIds)
            {
                var entity = db.EmployeeDepartment
                    .First(x => x.EmployeeId == employeeId && x.DepartmentId == departmentId);

                db.EmployeeDepartment.Remove(entity);
            }

            return db.SaveChanges();
        }
    }
}