using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.WebApp.Models;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private readonly EmployeeService _employeeService = new EmployeeService();

        public IActionResult Index()
        {
            DashboardViewModel model=new DashboardViewModel();
            model.EmployeeCount=_employeeService.GetAll().Count();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}