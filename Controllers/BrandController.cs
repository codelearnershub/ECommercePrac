using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;


        public BrandController(IBrandService brandService , IProductService productService , IStoreService storeService)
        {
            _brandService = brandService;
            _productService = productService;
            _storeService = storeService;
        }

        public IActionResult Index()
        {
            
            return View(_brandService.GetAllBrands());
        }
        public IActionResult Create()
        {
            var products = _productService.GetAllProducts();
            ViewData["Products"] = new SelectList(products, "Id", "ProductName");

            var stores = _storeService.GetAllStores();
            ViewData["Stores"] = new SelectList(stores, "Id", "StoreName");
            return View();
        }
        [HttpPost]
        public IActionResult Create (CreateBrandRequestModel model)
        {
            _brandService.AddBrand(model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var brand = _brandService.GetBrand(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateBrandRequestModel model)
        {
            _brandService.UpdateBrand(id, model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details (int id)
        {
            var brand = _brandService.GetBrand(id);
            if(brand == null)
            {
                return NotFound();
            }
            return View(brand);
            
        }
        public IActionResult Delete (int id)
        {
            var brand = _brandService.GetBrand(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }
        [HttpPost , ActionName("Delete")]
        public IActionResult DeleteConfirmed (int id)
        {
           
            _brandService.DeleteBrand(id);
            return RedirectToAction(nameof(Index));

        }

    }
}
