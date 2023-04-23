using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.WebApp.Models;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class SalaryPaymentController : Controller
    {
        SalaryPaymentService _salaryPaymentService = new SalaryPaymentService();
        EmployeeService _employeeService = new EmployeeService();
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalaryPaymentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalaryPaymentController/Create
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

        // GET: SalaryPaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalaryPaymentController/Delete/5
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
