using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
      


        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {

            return View(_categoryService.GetAllCategories());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryRequestModel model)
        {
            _categoryService.AddCategory(model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Update(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateCategoryRequestModel model)
        {
            _categoryService.UpdateCategory(id, model);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {

            _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
