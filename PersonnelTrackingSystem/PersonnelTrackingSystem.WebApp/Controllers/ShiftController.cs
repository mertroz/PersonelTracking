using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Shifts;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class ShiftController : Controller
    {
        // GET: ShiftController
        public ActionResult Index()
        {
            List<ShiftDto> list = new List<ShiftDto>();
            return View(list);
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
