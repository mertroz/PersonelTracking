using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Permissions;
using PersonnelTrackingSystem.WebApp.Models;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class PermissionController : Controller
    {
        private readonly PermissionService _permissionService = new PermissionService();
        private readonly EmployeeService _employeeService = new EmployeeService();

        // GET: PermissionController
        public ActionResult Index()
        {
            var permissions = _permissionService.GetAll().Select(s => new PermissionViewModel
            {
                EmployeeId = s.EmployeeId,
                PermitDate = s.PermitDate,
                EmployeeName = _employeeService.GetFullNameById(s.EmployeeId),
                Id = s.Id
            });
            return View(permissions);
        }

        // GET: PermissionController/Create
        public ActionResult Create()
        {
            PermissionViewModel permissionViewModel = new PermissionViewModel();
            permissionViewModel.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();

            permissionViewModel.PermitDate = DateTime.Now.Date;
          
            return View(permissionViewModel);
        }

        // POST: PermissionController/Create
        [HttpPost]
        public ActionResult Create(PermissionViewModel permission)
        {
            PermissionDto permissionDto = new PermissionDto()
            {
                EmployeeId = permission.EmployeeId, 
                PermitDate = permission.PermitDate,
            };

            var result = _permissionService.Create(permissionDto);
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

        // GET: PermissionController/Edit/5
        public ActionResult Update(int id)
        {
            PermissionViewModel model = new PermissionViewModel();
            model.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();

            PermissionDto permissionDto = _permissionService.GetById(id);
            model.PermitDate = permissionDto.PermitDate;
            model.EmployeeId = permissionDto.EmployeeId;

            return View(model);

        }

        // POST: PermissionController/Edit/5
        [HttpPost]
        public ActionResult Update(PermissionDto permission)
        {
            var commandResult = _permissionService.Update(permission);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {

                TempData["ResultMessage"] = commandResult.Message;
                return View(permission);
            }
        }

        // POST: PermissionController/Delete/5
        [HttpPost]
        public ActionResult Delete(PermissionDto permission)
        {
            var commandResult = _permissionService.Delete(permission);
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
