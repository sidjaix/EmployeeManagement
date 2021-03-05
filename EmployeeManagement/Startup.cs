using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement
{
  public class Startup
  {
    private IConfiguration _config;

    public Startup(IConfiguration config)
    {
      _config = config;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      //  https://docs.microsoft.com/en-us/aspnet/core/migration/22-to-30?
      //  view=aspnetcore-3.0&tabs=visual-studio#use-mvc-without-endpoint-routing

      services.AddDbContextPool<AppDbContext>(
          options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
      services.AddIdentity<IdentityUser, IdentityRole>()
          .AddEntityFrameworkStores<AppDbContext>();
      services.AddMvc(options => options.EnableEndpointRouting = false);
      //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
      services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();
      app.UseAuthentication();
      app.UseMvc(routes =>
        routes.MapRoute(
             name: "default",
             template: "{controller=Home}/{action=Index}/{id?}"
          ));

      //app.Run(async (context) =>
      //{
      //  await context.Response.WriteAsync("Hello World!");
      //});

      // app.UseRouting();
      //app.UseEndpoints(endpoints =>
      //{
      //  endpoints.MapControllerRoute(
      //              name: "default",
      //              pattern: "{controller=Home}/{action=Index}/{id?}");
      //});
      //});
    }
  }
}
