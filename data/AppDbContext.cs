using EmployeeApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
      public DbSet<EmployeeEntity> Employees { get; set; } = null!;
   
}

