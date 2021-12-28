using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BrandController(IBrandService brandService , IProductService productService , IStoreService storeService, IWebHostEnvironment webHostEnvironment)
        {
            _brandService = brandService;
            _productService = productService;
            _storeService = storeService;
            _webHostEnvironment = webHostEnvironment;

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
        public IActionResult Create (CreateBrandRequestModel model, IFormFile imageFile)
        {
            if(imageFile != null)
            {
                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(imageDirectory);
                string contentType = imageFile.FileName.Split('.')[1];
                string brandImage = $"ECM{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(imageDirectory, brandImage);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                model.BrandImage = brandImage;
            }
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
