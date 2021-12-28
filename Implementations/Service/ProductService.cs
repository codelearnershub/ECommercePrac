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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository , ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public bool AddProduct(CreateProductRequestModel model)
        {
            if(_productRepository.ProductExists(model.ProductName))
            {
                throw new Exception($"Product with name {model.ProductName} already exists");
            }
            var product = new Product
            {
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Description = model.Description,
                ProductName = model.ProductName,
                IsDeleted = false,
                
                
            };
            var categories = _categoryRepository.GetSelectedCategories(model.Categories);
            foreach(var category in categories)
            {
                var productCategory = new ProductCategory
                {
                    Product = product,
                    CategoryId = category.Id,
                    Category = category,
                    ProductId = product.Id
                };
                product.ProductCategories.Add(productCategory);
            }
            _productRepository.Create(product);
            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _productRepository.Get(id);
            _productRepository.Delete(product);
            return true;
        }

        public ProductDto Get(int id)
        {
            var product = _productRepository.Get(id);
            return new ProductDto
            {
                Id = product.Id,
                Description = product.Description,
                Brands = product.Brands.Select(a => new BrandDto
                {
                    BrandName = a.BrandName,
                    BrandImage = a.BrandImage
                }).ToList(),
                ProductName = product.ProductName,
                Categories = product.ProductCategories.Select(b => new CategoryDto
                {
                    Id = b.CategoryId,
                    CategoryName = b.Category.CategoryName,
                    Description = b.Category.Description
                }).ToList(),
             
                
                
                
            };
        }

        public IList<ProductDto> GetAllProducts()
        {
            return _productRepository.GetAll().Select(a => new ProductDto
            {
                Id = a.Id,
                Description = a.Description,
                Brands = a.Brands.Select(b => new BrandDto
                {
                    BrandName = b.BrandName,
                    BrandImage = b.BrandImage
                }).ToList(),
                ProductName = a.ProductName,
                Categories = a.ProductCategories.Select(c => new CategoryDto
                {
                    Id = c.CategoryId,
                    CategoryName = c.Category.CategoryName,
                    Description = c.Category.Description
                }).ToList(),
               
            }).ToList();
        }

       

        public bool UpdateProduct(int id, UpdateProductRequestModel model)
        {
            var product = _productRepository.Get(id);
            product.ProductName = model.ProductName;
            product.Description = model.Description;
            _productRepository.Update(product);
            return true;
        }
    }
}
