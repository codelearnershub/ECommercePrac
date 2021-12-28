using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;



        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public IActionResult Index()
        {

            return View(_roleService.GetAllRoles());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateRoleRequestModel model)
        {
            _roleService.AddRole(model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var role = _roleService.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateRoleRequestModel model)
        {
            _roleService.UpdateRole(id, model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var role = _roleService.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);

        }
        public IActionResult Delete(int id)
        {
            var role = _roleService.GetRole(id);
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _roleService.GetRole(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
