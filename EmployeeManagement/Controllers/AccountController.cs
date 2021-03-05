﻿using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
  public class AccountController : Controller
  {
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
      this.userManager = userManager;
      this.signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
      await signInManager.SignOutAsync();
      return RedirectToAction("index", "home");
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
      return View();
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      if(ModelState.IsValid)
      {
        var user = new IdentityUser { UserName=model.Email, Email=model.Email };
        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
          // Keep the logged in user information in the session memory using (isPersistent: false)
          await signInManager.SignInAsync(user, isPersistent: false);
          return RedirectToAction("Index", "home");
        }

        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      return View(model);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
      return View();
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      if (ModelState.IsValid)
      {
        var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

        if (result.Succeeded)
        {
          return RedirectToAction("Index", "home");
        }

          ModelState.AddModelError(string.Empty, "Invalid Username or Password");
      }

      return View(model);
    }
  }
}
