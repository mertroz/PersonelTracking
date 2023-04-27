using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Permissions;
using PersonnelTrackingSystem.WebApp.Models;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize]
    public class PermissionController : Controller
    {
        private readonly PermissionService _permissionService = new PermissionService();
        private readonly EmployeeService _employeeService = new EmployeeService();

        public ActionResult Index()
        {
            var permissions = _permissionService.GetAllByUser(User).Select(s => new PermissionViewModel
            {
                EmployeeId = s.EmployeeId,
                PermitStartDate = s.PermitStartDate,
                PermitEndDate = s.PermitEndDate,
                EmployeeName = _employeeService.GetFullNameById(s.EmployeeId),
                Id = s.Id
            });
            return View(permissions);
        }

        public ActionResult Create()
        {
            PermissionViewModel permissionViewModel = new PermissionViewModel();
            permissionViewModel.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();

            permissionViewModel.PermitStartDate = DateTime.Now.Date;
            permissionViewModel.PermitEndDate = DateTime.Now.Date.AddDays(1);
          
            return View(permissionViewModel);
        }

        [HttpPost]
        public ActionResult Create(PermissionViewModel permission)
        {
            if (permission.PermitStartDate>permission.PermitEndDate)
            {
                TempData["ResultMessage"] = "İzin başlangıç tarihi bitiş tarihinden büyük olamaz.";
                return View(permission);
            }
            PermissionDto permissionDto = new PermissionDto()
            {
                EmployeeId = permission.EmployeeId, 
                PermitStartDate = permission.PermitStartDate,
                PermitEndDate = permission.PermitEndDate
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
                return View(permission);
            }
        }

        public ActionResult Update(int id)
        {
            PermissionViewModel model = new PermissionViewModel();
            model.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();

            PermissionDto permissionDto = _permissionService.GetById(id);
            model.Id = permissionDto.Id;
            model.PermitStartDate = permissionDto.PermitStartDate;
            model.PermitEndDate = permissionDto.PermitEndDate;
            model.EmployeeId = permissionDto.EmployeeId;

            return View(model);

        }

        [HttpPost]
        public ActionResult Update(PermissionDto permissionDto)
        {
            if (permissionDto.PermitStartDate > permissionDto.PermitEndDate)
            {
                TempData["ResultMessage"] = "İzin başlangıç tarihi bitiş tarihinden büyük olamaz.";
                PermissionViewModel model = new PermissionViewModel();
                model.Employees = _employeeService.GetAllByUser(User).Select(x => new EmployeeViewModel
                {
                    FullName = x.FirstName + ' ' + x.LastName,
                    Id = x.Id
                }).ToList();

                model.Id = permissionDto.Id;
                model.PermitStartDate = permissionDto.PermitStartDate;
                model.PermitEndDate = permissionDto.PermitEndDate;
                model.EmployeeId = permissionDto.EmployeeId;

                return View(model);
            }

            var commandResult = _permissionService.Update(permissionDto);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ResultMessage"] = commandResult.Message;
                PermissionViewModel model = new PermissionViewModel();
                model.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
                {
                    FullName = x.FirstName + ' ' + x.LastName,
                    Id = x.Id
                }).ToList();

                model.Id = permissionDto.Id;
                model.PermitStartDate = permissionDto.PermitStartDate;
                model.PermitEndDate = permissionDto.PermitEndDate;
                model.EmployeeId = permissionDto.EmployeeId;

                return View(model);
            }
        }

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
