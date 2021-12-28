
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
    public class ProductController : Controller
    {
 
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;



        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {

            return View(_productService.GetAllProducts());
        }
        public IActionResult Create()
        {
            var categories = _categoryService.GetAllCategories();
            ViewData["Categories"] = new SelectList(categories, "Id", "CategoryName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductRequestModel model)
        {
            _productService.AddProduct(model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateProductRequestModel model)
        {
            _productService.UpdateProduct(id, model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);

        }
        public IActionResult Delete(int id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
