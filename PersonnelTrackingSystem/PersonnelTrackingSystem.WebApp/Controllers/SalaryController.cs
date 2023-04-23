using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.SalaryCalculators;
using PersonnelTrackingSystem.Users;
using PersonnelTrackingSystem.WebApp.Models;
using System.Data;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        SalaryCalculatorService _salaryCalculatorService = new SalaryCalculatorService();
        EmployeeService _employeeService = new EmployeeService();
        // GET: SalaryController
        public ActionResult Index()
        {
            List<SalaryViewModel> model = _salaryCalculatorService.GetAll().Select(x => new SalaryViewModel
            {
                Bonus = x.Bonus,
                EmployeeId = x.EmployeeId,
                EmployeeName = _employeeService.GetFullNameById(x.EmployeeId),
                Id = x.Id,
                MealAllowance = x.MealAllowance,
                Salary = x.Salary,
                TransportationAllowance = x.TransportationAllowance
            }).ToList();
            return View(model);
        }

        // GET: SalaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalaryController/Create
        public ActionResult Create()
        {
            SalaryCalculatorViewModel salaryCalculatorViewModel = new SalaryCalculatorViewModel();
            salaryCalculatorViewModel.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();

            return View(salaryCalculatorViewModel);
        }

        // POST: SalaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaryCalculatorViewModel model)
        {
            SalaryCalculatorDto salaryCalculatorDto = _salaryCalculatorService.GetByEmployeeId(model.EmployeeId);
            if (salaryCalculatorDto!=null)
            {
                TempData["ResultMessage"] = "Bu kullanıcıya ait maaş bilgisi zaten mevcut.";
                return View();
            }

            salaryCalculatorDto = new SalaryCalculatorDto();
            salaryCalculatorDto.Id = model.Id;
            salaryCalculatorDto.EmployeeId = model.EmployeeId;
            salaryCalculatorDto.Bonus = model.Bonus;
            salaryCalculatorDto.TransportationAllowance = model.TransportationAllowance;
            salaryCalculatorDto.Salary = model.Salary;


            var result = _salaryCalculatorService.Create(salaryCalculatorDto);
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

        // GET: SalaryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalaryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SalaryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalaryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
