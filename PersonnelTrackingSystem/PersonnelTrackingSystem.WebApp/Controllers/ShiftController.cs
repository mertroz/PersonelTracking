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

        // GET: ShiftController
        [Authorize, Authorize(Roles = "Admin")]
        public ActionResult EmployeeShifts()
        {
            List<ShiftDto> shifts = _shiftService.GetAll().ToList();
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

        // GET: ShiftController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShiftController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShiftController/Create
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

        // GET: ShiftController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShiftController/Edit/5
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

        // GET: ShiftController/Delete/5
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
