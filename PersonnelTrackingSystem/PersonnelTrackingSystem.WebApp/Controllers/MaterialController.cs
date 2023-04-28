using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Materials;
using PersonnelTrackingSystem.WebApp.Models;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]
    public class MaterialController : Controller
    {
        private readonly MaterialService _materialService = new MaterialService();
        private readonly EmployeeService _employeeService = new EmployeeService();
        // GET: MaterialController
        public ActionResult Index()
        {
            var materials = _materialService.GetAllByUser(User).Select(s => new MaterialViewModel
            {
                EmployeeId= s.EmployeeId,
                EmployeeName = _employeeService.GetFullNameById(s.EmployeeId),
                Id= s.Id,
                Request = s.Request,

            });
            return View(materials);
        }

        // GET: MaterialController/Create
        public ActionResult Create()
        {
            MaterialViewModel materialViewModel = new MaterialViewModel();
            materialViewModel.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();
           

            return View(materialViewModel);
        }

        // POST: MaterialController/Create
        [HttpPost]
        public ActionResult Create(MaterialDto material)
        {
            MaterialDto materialDto = new MaterialDto()
            {
               EmployeeId= material.EmployeeId,
               Id= material.Id,
               Request= material.Request, 
               
            };

            var result = _materialService.Create(materialDto);
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

        public ActionResult Update(int id)
        {
            MaterialViewModel model = new MaterialViewModel();
            model.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();


            MaterialDto materialDto = _materialService.GetById(id);
            model.EmployeeId = materialDto.EmployeeId;
            model.Request = materialDto.Request;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MaterialDto material)
        {
            var commandResult = _materialService.Update(material);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {

                TempData["ResultMessage"] = commandResult.Message;
                return View(material);
            }
        }

        // GET: MaterialController/Delete/5
        public ActionResult Delete(MaterialDto material)
        {
            var commandResult = _materialService.Delete(material);
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
