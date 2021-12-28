using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;



        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {

            return View(_customerService.GetAllCustomers());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCustomerRequestModel model)
        {
            _customerService.AddCustomer(model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateCustomerRequestModel model)
        {
            _customerService.UpdateCustomer(id, model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);

        }
        public IActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _customerService.GetCustomer(id);
            return RedirectToAction(nameof(Index));

        }
    }
}

