using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task2.Models;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}