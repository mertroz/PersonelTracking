using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Users;
using PersonnelTrackingSystem.WebApp.Models;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService = new UserService();
        private readonly EmployeeService _employeeService = new EmployeeService();
        private readonly RoleService _roleService = new RoleService();
        // GET: UserController
        public ActionResult Index()
        {
            var users = _userService.GetAll().Select(s => new UserViewModel
            {
                Password = s.Password,
                UserName = s.UserName,
                RoleId = s.RoleId,
                EmployeeName = _employeeService.GetFullNameById(s.EmployeeId),
                RoleName=_roleService.GetRoleNameById(s.RoleId),
                Id = s.Id
            });
            return View(users);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();
            userViewModel.Roles = _roleService.GetAll().Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return View(userViewModel);
        }

        // POST: UserController/Create
        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            UserDto userDto = new UserDto()
            {
                EmployeeId = user.EmployeeId,
                Password = user.Password,
                RoleId = user.RoleId,
                UserName = user.UserName
            };

            var result = _userService.Create(userDto);
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

        // GET: UserController/Update/5
        public ActionResult Update(int id)
        {
            UserViewModel model = new UserViewModel();
            model.Employees = _employeeService.GetAll().Select(x => new EmployeeViewModel
            {
                FullName = x.FirstName + ' ' + x.LastName,
                Id = x.Id
            }).ToList();
            model.Roles = _roleService.GetAll().Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            UserDto userDto=_userService.GetById(id);
            model.UserName = userDto.UserName;
            model.EmployeeId = userDto.EmployeeId;
            model.Password = userDto.Password;
            model.RoleId = userDto.RoleId;
            
            return View(model);
        }

        // POST: UserController/Update/5
        [HttpPost]
        public ActionResult Update(UserDto user)
        {
            var commandResult = _userService.Update(user);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {

                TempData["ResultMessage"] = commandResult.Message;
                return View(user);
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(UserDto user)
        {
            var commandResult = _userService.Delete(user);
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
