﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.SalaryPayments;
using PersonnelTrackingSystem.WebApp.Models;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class SalaryPaymentController : Controller
    {
        SalaryPaymentService _salaryPaymentService = new SalaryPaymentService();
        EmployeeService _employeeService = new EmployeeService();
        SalaryCalculatorService _salaryCalculatorService = new SalaryCalculatorService();
        // GET: SalaryPaymentController
        public ActionResult Index()
        {
            List<SalaryPaymentViewModel> model = _salaryPaymentService.GetAll().Select(x => new SalaryPaymentViewModel
            {
                Amount = x.Amount,
                EmployeeId = x.EmployeeId,
                EmployeeName = _employeeService.GetFullNameById(x.EmployeeId),
                Id = x.Id,
                MonthName = GetMonthName(x.Month),
                Month = x.Month,
                Paid = x.Paid,
                Year = x.Year
            }).ToList();
            return View(model);
        }

        private string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "Ocak";
                case 2:
                    return "Şubat";
                case 3:
                    return "Mart";
                case 4:
                    return "Nisan";
                case 5:
                    return "Mayıs";
                case 6:
                    return "Haziran";
                case 7:
                    return "Temmuz";
                case 8:
                    return "Ağustos";
                case 9:
                    return "Eylül";
                case 10:
                    return "Ekim";
                case 11:
                    return "Kasım";
                case 12:
                    return "Aralık";
                default: return "";


            }
        }



        // GET: SalaryPaymentController/Details/5
        public ActionResult AllMonthPayment()
        {
            return View();
        }

        // POST: SalaryPaymentController/Create
        [HttpPost]
        public ActionResult AllMonthPayment(SalaryPaymentSaveModel model)
        {
            var salaryPayment = _salaryPaymentService.GetAll().Where(x => x.Month == model.Month && x.Year == model.Year).ToList();
            if (salaryPayment.Count > 0)
            {
                TempData["ResultMessage"] = "Bu tarih için girilmiş ödeme kayıtları mevcut toplu kayıt yapamazsınız!!";
                return View();
            }
            else
            {
                var employees = _employeeService.GetAll();

                foreach (var employee in employees)
                {
                    var salaryCalc = _salaryCalculatorService.GetByEmployeeId(employee.Id);
                    if (salaryCalc != null)
                    {
                        var amount = salaryCalc.TransportationAllowance + salaryCalc.Salary + salaryCalc.MealAllowance + salaryCalc.Bonus;
                        SalaryPaymentDto salaryPaymentDto = new SalaryPaymentDto()
                        {
                            Amount = amount,
                            EmployeeId = employee.Id,
                            Month = model.Month,
                            Year = model.Year,
                            Paid = false
                        };
                        var result = _salaryPaymentService.Create(salaryPaymentDto);
                    }

                }

                TempData["ResultMessage"] = "Ödeme kayıtları başarıyla yapıldı.";
                return RedirectToAction("Index");
            }



        }

        // GET: SalaryPaymentController/Delete/5
        public IActionResult Delete(int id)
        {
            var salaryPayment = _salaryPaymentService.GetById(id);
            if (salaryPayment != null)
            {
                var commandResult = _salaryPaymentService.Delete(salaryPayment);
                if (commandResult.IsSuccess)
                {
                    TempData["ResultMessage"] = commandResult.Message;
                }
                else
                {
                    ViewBag.ResultMessage = commandResult.Message;
                }
            }
            else
            {
                TempData["ResultMessage"] = "Kayıt bulunamadı";
            }
            return RedirectToAction("Index");

        }

        // GET: SalaryPaymentController/Create
        public ActionResult Create()
        {
            SalaryPaymentViewModel model = new SalaryPaymentViewModel();
            model.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();
            return View();
        }

        // POST: SalaryPaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaryPaymentViewModel model)
        {
            var salaryCalc = _salaryCalculatorService.GetByEmployeeId(model.EmployeeId);
            if (salaryCalc != null)
            {
                var amount = salaryCalc.TransportationAllowance + salaryCalc.Salary + salaryCalc.MealAllowance + salaryCalc.Bonus;
                SalaryPaymentDto salaryPaymentDto = new SalaryPaymentDto()
                {
                    Amount = amount,
                    EmployeeId = model.EmployeeId,
                    Month = model.Month,
                    Year = model.Year,
                    Paid = false
                };
                var result = _salaryPaymentService.Create(salaryPaymentDto);
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = "Bu kullanıcı için maaş bilgileri girilmesi gerekiyor.";
                return View();
            }
        }

        // GET: SalaryPaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalaryPaymentController/Edit/5
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

        
        
    }
}
