using ECommerce.Entities;
using ECommerce.Interfaces.IRepositories;
using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public bool AddCategory(CreateCategoryRequestModel model)
        {
            if(_categoryRepository.CategoryExists(model.CategoryName))
            {
                throw new Exception($"Category with name {model.CategoryName} already exists");
            }
            var category = new Category
            {
                CategoryName = model.CategoryName,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Description = model.Description,
                IsDeleted = false,

            };
            _categoryRepository.Create(category);
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = _categoryRepository.Get(id);
            _categoryRepository.Delete(category);
            return true;
        }

        public IList<CategoryDto> GetAllCategories()
        {
            return _categoryRepository.GetAll().Select(a => new CategoryDto
            {
                CategoryName = a.CategoryName,
                Description = a.Description,
                Id = a.Id,
                Products = a.ProductCategories.Select(b => new ProductDto
                {
                    Id = b.ProductId,
                    ProductName = b.Product.ProductName,
                    Description = b.Product.Description,
                    Brands = b.Product.Brands.Select(c => new BrandDto
                    {
                        BrandName = c.BrandName
                    }).ToList()
                }).ToList()

            }).ToList();
        }

        public CategoryDto GetCategory(int id)
        {
            var category = _categoryRepository.Get(id);
            return new CategoryDto
            {

                CategoryName = category.CategoryName,
                Description = category.Description,
                Id = category.Id,
                Products = category.ProductCategories.Select(a => new ProductDto
                {
                    ProductName = a.Product.ProductName,
                    Description = a.Product.Description,
                }).ToList()
            };
        }

        public bool UpdateCategory(int id, UpdateCategoryRequestModel model)
        {
            var category = _categoryRepository.Get(id);
            category.Description = model.Description;
            category.CategoryName = model.CategoryName;
            _categoryRepository.Update(category);
            return true;
        }
    }
}
