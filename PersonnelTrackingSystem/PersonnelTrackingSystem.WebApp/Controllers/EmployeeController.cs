using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.WebApp.Helper;
using System.Security.Claims;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize, Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService = new EmployeeService();
        public IActionResult Index()
        {
            List<EmployeeDto> models = new List<EmployeeDto>();
            if (User.IsInRole("Admin"))
            {
                models = _employeeService.GetAll().ToList();
            }
            else
            {
                int employeeId = Convert.ToInt32(User.Claims.FirstOrDefault(w => w.Type == ClaimTypes.NameIdentifier).Value);
                models = models.Where(w => w.Id == employeeId).ToList();
            }
            return View(models);
        }

        public IActionResult Create()
        {
            EmployeeDto newEmployee = new EmployeeDto()
            {
                HiringDate = DateTime.Now.Date
            };

            return View(newEmployee);
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            var result = _employeeService.Create(employee);
            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
               
                TempData["ResultMessage"] = result.Message;
                return View();
            }
        }

        public IActionResult Delete(EmployeeDto employee)
        {
            var commandResult = _employeeService.Delete(employee);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var employee = _employeeService.GetById(id);


            if (employee != null)
            {
                return View(employee);
            }
            else
            {
                TempData[Keys.ErrorMessage] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Update(EmployeeDto employee)
        {
            var commandResult = _employeeService.Update(employee);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                
                TempData["ResultMessage"] = commandResult.Message;
                return View(employee);
            }
        }
    }
}
