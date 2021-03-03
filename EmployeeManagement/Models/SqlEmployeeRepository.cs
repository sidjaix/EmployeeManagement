using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SqlEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee CreateEmployee(Employee employee)
        {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int employeeId)
        {
            Employee employee = this.context.Employees.Find(employeeId);
            if (employee != null)
            {
                this.context.Employees.Remove(employee);
                this.context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return this.context.Employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return context.Employees.FirstOrDefault(emp => emp.Id == id);
        }

        public Employee UpdateEmployee(Employee employeeChange)
        {
            var employee = context.Employees.Attach(employeeChange);
            employee.State = EntityState.Modified;
            context.SaveChanges();
            return employeeChange;
        }
    }
}
