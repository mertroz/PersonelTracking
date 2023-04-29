using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Roles;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    [Authorize, Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleService _roleService = new RoleService();

        public ActionResult Index()
        {
            var roles = _roleService.GetAll();
            return View(roles);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleDto role)
        {
            var result = _roleService.Create(role);
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
            RoleDto roleDto = _roleService.GetById(id);

            return View(roleDto);
        }

        [HttpPost]
        public ActionResult Update(RoleDto role)
        {
            var commandResult = _roleService.Update(role);

            if (commandResult.IsSuccess)
            {
                TempData["ResultMessage"] = commandResult.Message;
                return RedirectToAction("Index");
            }
            else
            {

                TempData["ResultMessage"] = commandResult.Message;
                return View(role);
            }
        }
        public ActionResult Delete(RoleDto role)
        {
            var commandResult = _roleService.Delete(role);
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
