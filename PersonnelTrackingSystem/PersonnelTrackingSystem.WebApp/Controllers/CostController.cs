using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Costs;
using PersonnelTrackingSystem.WebApp.Models;
using System.Security.Claims;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class CostController : Controller
    {
        private readonly CostService _costService = new CostService();
        private readonly EmployeeService _employeeService = new EmployeeService();
        // GET: CostController
        public ActionResult Index()
        {
            List<CostViewModel> models = new List<CostViewModel>();
            if (User.IsInRole("Admin"))
            {
                models = _costService.GetAll().Select(s => new CostViewModel
                {
                    CostAmount = s.CostAmount,
                    CostType = GetCostType(s.CostType),
                    EmployeeName = _employeeService.GetFullNameById(s.EmployeeId),
                    Id = s.Id
                }).ToList();
            }
            else
            {
                int employeeId = Convert.ToInt32(User.Claims.FirstOrDefault(w => w.Type == ClaimTypes.NameIdentifier).Value);
                models = models.Where(w => w.EmployeeId == employeeId).ToList();
            }
            return View(models);

        }

        private string GetCostType(string costType)
        {
            switch (costType)
            {
                case "1":
                    return "Ulaşım";
                case "2":
                    return "Kırtasiye";
                case "3":
                    return "Konaklama";
                case "4":
                    return "Elektronik";

                default:
                    return "";
            }
        }


        // GET: CostController/Create
        public ActionResult Create()
        {
            CostViewModel costViewModel = new CostViewModel();
            costViewModel.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();


            return View(costViewModel);
        }

        // POST: CostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CostViewModel cost)
        {
            CostDto costDto = new CostDto()
            {
                Id = cost.Id,
                CostAmount = cost.CostAmount,
                CostType = cost.CostType,
                EmployeeId = cost.EmployeeId,
            };

            var result = _costService.Create(costDto);
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

        // GET: CostController/Edit/5
        public ActionResult Edit(int id)
        {
            CostViewModel model = new CostViewModel();
            model.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();


            CostDto costDto = _costService.GetById(id);
            model.CostAmount = costDto.CostAmount;
            model.CostType = costDto.CostType;
            model.EmployeeId = costDto.EmployeeId;

            return View(model);
        }

        // POST: CostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CostDto cost)
        {

            var commandResult = _costService.Update(cost);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {

                TempData["ResultMessage"] = commandResult.Message;
                return View(cost);
            }
        }

        // GET: CostController/Delete/5
        public ActionResult Delete(CostDto cost)
        {
            var commandResult = _costService.Delete(cost);
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
