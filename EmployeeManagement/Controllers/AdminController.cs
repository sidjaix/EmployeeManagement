using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
  public class AdminController : Controller
  {
    private readonly RoleManager<IdentityRole> roleManager;

    public AdminController(RoleManager<IdentityRole> roleManager)
    {
      this.roleManager = roleManager;
    }

    [HttpGet]
    public IActionResult CreateRole()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(RoleViewModel model)
    {
      if (ModelState.IsValid)
      {
        var role = new IdentityRole
        {
          Name = model.RoleName
        };

        var result = await roleManager.CreateAsync(role);

        if (result.Succeeded)
        {
          return RedirectToAction("Index", "home");
        }

        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }
      return View(model);
    }
  }
}
