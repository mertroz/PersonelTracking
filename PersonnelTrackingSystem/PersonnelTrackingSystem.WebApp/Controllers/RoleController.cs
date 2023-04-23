using Microsoft.AspNetCore.Mvc;
using PersonnelTrackingSystem.Business.Servicess;
using PersonnelTrackingSystem.Roles;

namespace PersonnelTrackingSystem.WebApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleService _roleService = new RoleService();
        // GET: RoleController
        public ActionResult Index()
        {
            var roles = _roleService.GetAll();
            return View(roles);
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
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

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            RoleDto roleDto = _roleService.GetById(id);

            return View(roleDto);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        public ActionResult Edit(RoleDto role)
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

        // GET: RoleController/Delete/5
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
