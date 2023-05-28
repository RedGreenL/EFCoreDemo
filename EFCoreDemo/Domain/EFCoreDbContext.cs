using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class EFCoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\\SQLEXPRESS;Database=EFCoreDemo;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.Address)
                .WithOne(x => x.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasKey(c => new { c.DepartmentId, c.EmployeeId });

            modelBuilder.InsertGrades();
            modelBuilder.InsertDepartments();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartment { get; set; }
    }
}
