using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
  [Authorize]
  public class HomeController : Controller
  {
    private readonly IEmployeeRepository _employeeRespository;
    public HomeController(IEmployeeRepository employeeRepository)
    {
      _employeeRespository = employeeRepository;
    }
    [AllowAnonymous]
    public IActionResult Index()
    {
      var employees = _employeeRespository.GetAllEmployee();
      return View(employees);
    }

    [AllowAnonymous]
    public IActionResult Detail(int? id)
    {
      Employee employee = _employeeRespository.GetEmployeeById(id ?? 1);
      return View(employee);
    }

    [HttpGet]
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
