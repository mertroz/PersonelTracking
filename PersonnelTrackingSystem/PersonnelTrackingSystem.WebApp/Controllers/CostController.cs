using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Costs;
using PersonnelTrackingSystem.WebApp.Models;
using System.Security.Claims;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]
    public class CostController : Controller
    {
        private readonly CostService _costService = new CostService();
        private readonly EmployeeService _employeeService = new EmployeeService();
       
        public ActionResult Index()
        {
            List<CostViewModel> models = new List<CostViewModel>();
            models = _costService.GetAllByUser(User).Select(s => new CostViewModel
            {
                CostAmount = s.CostAmount,
                CostType = GetCostType(s.CostType),
                EmployeeName = _employeeService.GetFullNameById(s.EmployeeId),
                Id = s.Id
            }).ToList();
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
                cost.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
                {
                    FullName = x.FirstName + ' ' + x.LastName,
                    Id = x.Id
                }).ToList();

                TempData["ResultMessage"] = result.Message;
                return View(cost);
            }
        }

        public ActionResult Update(int id)
        {
            CostViewModel model = new CostViewModel();
            model.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(CostDto cost)
        {

            var commandResult = _costService.Update(cost);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                CostViewModel model = new CostViewModel();
                model.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
                {
                    FullName = x.FirstName + ' ' + x.LastName,
                    Id = x.Id
                }).ToList();

                TempData["ResultMessage"] = commandResult.Message;
                model.CostAmount = cost.CostAmount;
                model.CostType = cost.CostType;
                model.EmployeeId = cost.EmployeeId;

                return View(model);
            }
        }

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
