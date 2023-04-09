using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Employees;
using PersonnelTrackingSystem.Shifts;
using PersonnelTrackingSystem.WebApp.Helper;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class ShiftController : Controller
    {
        private readonly ShiftService _shiftService = new ShiftService();
        private readonly EmployeeService _employeeService = new EmployeeService();

        public IActionResult Index()
        {
            var shift = _shiftService.GetAll();
            return View(shift);
        }
        public IActionResult Create()
        {
            ViewBag.Shifts = _shiftService.GetAll();
            return View();

        }

        [HttpPost]
        public IActionResult Create(ShiftDto shift)
        {
            var commandResult = _shiftService.Create(shift);
            ViewBag.Shifts = _shiftService.GetAll();

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
            var updateId = _shiftService.GetById(id);
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
        public IActionResult Update(ShiftDto shift)
        {

            var commandResult = _shiftService.Update(shift);
            if (commandResult.IsSuccess)
            {
                TempData[Keys.ResultMessage] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(shift);
            }
        }
        public IActionResult Delete(int id)
        {
            var shift = _shiftService.GetById(id);
            if (shift != null)
            {
                return View(shift);
            }
            else
            {
                TempData["ErrorMessage"] = "Kayıt Bulunamadı";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(ShiftDto shift)
        {
            var commandResult = _shiftService.Delete(shift);
            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ResultMessage = commandResult.Message;
                return View(shift);
            }
        }
    }
}
