﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.WebApp.Helper;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService = new EmployeeService();

        public IActionResult Index()
        {
            var employee = _employeeService.GetAll();
            return View(employee);
        }

         public IActionResult Create()
        {
            ViewBag.Employees = _employeeService.GetAll();
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            var commandResult = _employeeService.Create(employee);
            ViewBag.Employees = _employeeService.GetAll();
            if (commandResult.IsSuccess)
            {
                TempData[Keys.ResultMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View();
            }
        }
        public IActionResult Update(int id)
        {
            var updateId = _employeeService.GetById(id);
            if (updateId != null)
            {
                
                return View(updateId);
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
                TempData[Keys.ResultMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(employee);
            }
        }
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee != null)
            {
                return View(employee);
            }
            else
            {
                TempData["ErrorMessage"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(EmployeeDto employee)
        {
            var commandResult = _employeeService.Delete(employee);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(employee);
            }
        }

    }
}