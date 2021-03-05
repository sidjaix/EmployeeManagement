using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
  public static class ModelBuilderExtension
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Employee>().HasData(
        new Employee
        {
          Id = 1,
          Name = "Mark",
          Email = "mark@gmail.com",
          Department = Dept.HR
        },
        new Employee
        {
          Id = 2,
          Name = "Adam",
          Email = "adam@gmail.com",
          Department = Dept.IT
        });
    }
  }
}
