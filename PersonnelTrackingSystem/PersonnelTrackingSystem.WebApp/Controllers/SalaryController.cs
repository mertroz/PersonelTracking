using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]
    public class SalaryController : Controller
    {
        // GET: SalaryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SalaryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalaryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryController/Create
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
