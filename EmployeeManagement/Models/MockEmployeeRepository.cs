using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
  public class MockEmployeeRepository : IEmployeeRepository
  {
    private List<Employee> _employeeList;

    public MockEmployeeRepository()
    {
      _employeeList = new List<Employee>{
        new Employee { Id=1, Name="Harry", Department=Dept.IT, Email="harry@gmail.com"},
        new Employee { Id=2, Name="Adam", Department=Dept.HR, Email="adam@gmail.com"},
        new Employee { Id=3, Name="Mathew", Department=Dept.Accountant, Email="mathew@gmail.com"},
        new Employee { Id=4, Name="Jose", Department=Dept.Purchase, Email="jose@gmail.com"},
        };
    }
    public Employee GetEmployeeById(int id)
    {
      return _employeeList.FirstOrDefault(e => e.Id == id);
    }

    public IEnumerable<Employee> GetAllEmployee()
    {
      return _employeeList;
    }

    public Employee CreateEmployee(Employee employee)
    {
      employee.Id = _employeeList.Max(e => e.Id) + 1;
      _employeeList.Add(employee);
      return employee;
    }
  }
}
