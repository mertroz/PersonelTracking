using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Shifts;
using System.Collections.Generic;
using System.Data;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]
    public class ShiftController : Controller
    {
        private readonly ShiftService _shiftService = new ShiftService();

        [Authorize, Authorize(Roles = "Admin")]
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
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        public ActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, IFormCollection collection)
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

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShiftController/Delete/5
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
