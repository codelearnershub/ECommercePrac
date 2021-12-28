using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStoreService _storeService;
        private readonly IRoleService _roleService;


        public UserController(IStoreService storeService , IUserService userService, IRoleService roleService )
        {
            _storeService = storeService;
            _userService = userService;
            _roleService = roleService;
        }

     
        public IActionResult Index()
        {

            return View(_userService.GetAllUsers());
        }
        public IActionResult Create()
        {
            var roles = _roleService.GetAllRoles();
            ViewData["Roles"] = new SelectList(roles, "Id", "Name");

            var stores = _storeService.GetAllStores();
            ViewData["Stores"] = new SelectList(stores, "Id", "StoreName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserRequestModel model)
        {
            _userService.AddUser(model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateUserRequestModel model)
        {
            _userService.UpdateUser(id, model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }
        public IActionResult Delete(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Login ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email , string password)
        {
            var user = _userService.Login(email, password);
            if(user == null)
            {
                ViewBag.Message = "Invalid email or Password";
                    return View();
            }
            else
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, "Manager"),
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }
    }
}
