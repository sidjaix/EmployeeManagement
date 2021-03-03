using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
  public class HomeController : Controller
  {
    private readonly IEmployeeRepository _employeeRespository;
    public HomeController(IEmployeeRepository employeeRepository)
    {
      _employeeRespository = employeeRepository;
    }
    public IActionResult Index()
    {
      var employees = _employeeRespository.GetAllEmployee();
      return View(employees);
    }

    public IActionResult Detail(int? id)
    {
      Employee employee = _employeeRespository.GetEmployeeById(id ?? 1);
      return View(employee);
    }

    public ViewResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Employee employee)
    {
      if (ModelState.IsValid)
      {
        Employee newEmployee = _employeeRespository.CreateEmployee(employee);
        return RedirectToAction("Detail", new { id = newEmployee.Id });
      }
      return View();
    }
  }
}
