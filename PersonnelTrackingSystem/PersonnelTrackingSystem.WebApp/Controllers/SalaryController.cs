using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.SalaryCalculators;
using PersonnelTrackingSystem.Users;
using PersonnelTrackingSystem.WebApp.Models;
using System.Data;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SalaryController : Controller
    {
        SalaryCalculatorService _salaryCalculatorService = new SalaryCalculatorService();
        EmployeeService _employeeService = new EmployeeService();

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

        public ActionResult Update(int id)
        {
            SalaryCalculatorViewModel model = new SalaryCalculatorViewModel();
            SalaryCalculatorDto salaryCalculator = _salaryCalculatorService.GetById(id);

            model.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();

            model.Salary = salaryCalculator.Salary;
            model.EmployeeId = salaryCalculator.EmployeeId;
            model.TransportationAllowance = salaryCalculator.TransportationAllowance;
            model.Bonus = salaryCalculator.Bonus;
            model.MealAllowance = salaryCalculator.MealAllowance;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(SalaryCalculatorDto salaryCalculator)
        {
            var commandResult = _salaryCalculatorService.Update(salaryCalculator);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {

                TempData["ResultMessage"] = commandResult.Message;
                return View(salaryCalculator);
            }
        }

        public ActionResult Delete(SalaryCalculatorDto salaryCalculator)
        {
            var commandResult = _salaryCalculatorService.Delete(salaryCalculator);
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

    }
}
