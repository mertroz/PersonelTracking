using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Domain;
using PersonnelTrackingSystem.Materials;
using PersonnelTrackingSystem.Permissions;
using PersonnelTrackingSystem.Shifts;
using PersonnelTrackingSystem.WebApp.Models;
using System.Collections.Generic;
using System.Data;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]
    public class ShiftController : Controller
    {
        private readonly ShiftService _shiftService = new ShiftService();
        private readonly EmployeeService _employeeService = new EmployeeService();

        [Authorize]
        public ActionResult EmployeeShifts()
        {
            List<ShiftDto> shifts = _shiftService.GetAllByUser(User).ToList();
            return View(shifts);
        }

        public ActionResult MyShifts()
        {
            List<ShiftDto> shifts = _shiftService.GetAll().ToList();
            return View(shifts);

        }
        public ActionResult Index()
        {
            List<ShiftViewModel> shifts = _shiftService.GetAllByUser(User).Select(s => new ShiftViewModel
            {
                EmployeeId= s.EmployeeId,
                EmployeeName = _employeeService.GetFullNameById(s.EmployeeId),
                Id= s.Id,
                WorkingDate= s.WorkingDate,
                WorkingTime= s.WorkingTime
            }).ToList();
            return View(shifts);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ShiftViewModel model=new ShiftViewModel();
            model.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();
            model.WorkingDate = DateTime.Now;
            model.WorkingTime = DateTime.Now.Date;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShiftViewModel shift)
        {
            ShiftDto shiftDto = new ShiftDto()
            {
                WorkingTime= shift.WorkingTime,
                EmployeeId= shift.EmployeeId,   
                WorkingDate= shift.WorkingDate,
                Id=shift.Id
            };

            var result = _shiftService.Create(shiftDto);
            if (result.IsSuccess)
            {
                TempData["ResultMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = result.Message;
                return View(shift);
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Update(int id)
        {
            ShiftViewModel model = new ShiftViewModel();
            model.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();
            ShiftDto shiftDto=_shiftService.GetById(id);
            model.WorkingTime = shiftDto.WorkingTime;
            model.EmployeeId = shiftDto.EmployeeId;
            model.WorkingDate = shiftDto.WorkingDate;
            model.Id = shiftDto.Id; 
            return View(model);  

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ShiftDto shift)
        {
            var commandResult = _shiftService.Update(shift);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {

                TempData["ResultMessage"] = commandResult.Message;
                return View(shift);
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(ShiftDto shift)
        {
            var commandResult = _shiftService.Delete(shift);
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
