using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;


        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IActionResult Index()
        {

            return View(_storeService.GetAllStores());
        }
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateStoreRequestModel model)
        {
            _storeService.AddStore(model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var store = _storeService.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateStoreRequestModel model)
        {
            _storeService.UpdateStore(id, model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var store = _storeService.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }
            return View(store);

        }
        public IActionResult Delete(int id)
        {
            var store = _storeService.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }
            return View(store);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _storeService.DeleteStore(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
