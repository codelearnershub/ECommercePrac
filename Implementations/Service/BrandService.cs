using ECommerce.Entities;
using ECommerce.Enum;
using ECommerce.Interfaces.IRepositories;
using ECommerce.Interfaces.IServices;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Implementations.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IStoreRepository _storeRepository;

        public BrandService(IBrandRepository brandRepository, IStoreRepository storeRepository)
        {
            _brandRepository = brandRepository;
            _storeRepository = storeRepository;
        }

        public bool AddBrand(CreateBrandRequestModel model)
        {
            var brandExists = _brandRepository.BrandExists(model.BrandName);
            if(brandExists)
            {
                throw new Exception($"brand name with brand name {model.BrandName} already exist");
            }
            else
            {
                var brand = new Brand
                {
                    BrandName = model.BrandName,
                    SKU = model.SKU,
                    BrandImage = model.BrandImage,
                    BrandStatus = BrandStatus.Available,
                    ProductId = model.ProductId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    Price = model.Price
                };
                var stores = _storeRepository.GetSelectedStores(model.Stores);
                foreach (var store in stores)
                {
                    var storeBrand = new StoreBrand
                    {
                        StoreId = store.Id,
                        Store = store,
                        BrandId = brand.Id,
                        Brand = brand,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
                    };
                    brand.StoreBrands.Add(storeBrand);
                }
                _brandRepository.Create(brand);
                return true;

            }
        }

        public bool DeleteBrand(int id)
        {
            var brand = _brandRepository.Get(id);
            _brandRepository.Delete(brand);
            return true;
        }

        public IList<BrandDto> GetAllBrands()
        {
            return _brandRepository.GetAll().Select(a => new BrandDto
            {
                Id = a.Id,
                BrandName = a.BrandName,
                BrandImage = a.BrandImage,
                BrandStatus = a.BrandStatus,
                ProductId = a.ProductId,
                ProductName = a.Product.ProductName,
                Price = a.Price,
                SKU = a.SKU,
                Orders = a.OrderBrands.Select(b => new OrderDto
                {
                    Id = b.Id,
                    OrderDate = b.DateCreated,
                }).ToList(),
                Stores = a.StoreBrands.Select(c => new StoreDto
                {
                    Id = c.Id,
                    StoreName = c.Store.StoreName,
                }).ToList(),
                
            }).ToList();
        }

        public BrandDto GetBrand(int id)
        {
            var a = _brandRepository.Get(id);
            return new BrandDto
            {
                Id = a.Id,
                BrandName = a.BrandName,
                BrandImage = a.BrandImage,
                BrandStatus = a.BrandStatus,
                ProductId = a.ProductId,
                ProductName = a.Product.ProductName,
                Price = a.Price,
                SKU = a.SKU,
                Orders = a.OrderBrands.Select(b => new OrderDto
                {
                    Id = b.OrderId,
                    OrderDate = b.DateCreated,
                }).ToList(),
                Stores = a.StoreBrands.Select(c => new StoreDto
                {
                    Id = c.StoreId,
                    StoreName = c.Store.StoreName,
                }).ToList(),
            };
        }

        public bool UpdateBrand(int id, UpdateBrandRequestModel model)
        {
            var brand = _brandRepository.Get(id);
            brand.BrandName = model.BrandName;
            brand.BrandImage = model.BrandImage;
            brand.Price = model.Price;
            _brandRepository.Update(brand);
            return true;
            
            

                


        }

        public bool UpdateBrandStatus(int id, BrandStatus status)
        {
            var brand = _brandRepository.Get(id);
            brand.BrandStatus = status;
            _brandRepository.Update(brand);
            return true;
        }
    }
}
