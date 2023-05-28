using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public static class SeedDbData
{
    public static void InsertGrades(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>().HasData(new List<Grade>()
        {
            new() { Id = Guid.NewGuid(), Name = "Junior" },
            new() { Id = Guid.NewGuid(), Name = "Middle" },
            new() { Id = Guid.NewGuid(), Name = "Senior" }
        });
    }

    public static void InsertDepartments(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(new List<Department>()
        {
            new() { Id = Guid.NewGuid(), Name = "Management" },
            new() { Id = Guid.NewGuid(), Name = "Discipline" },
            new() { Id = Guid.NewGuid(), Name = "Development" },
            new() { Id = Guid.NewGuid(), Name = "Testing" }
        });
    }
}