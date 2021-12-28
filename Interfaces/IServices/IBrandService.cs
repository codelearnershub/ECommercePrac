using ECommerce.Enum;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IServices
{
    public interface IBrandService
    {
        bool AddBrand(CreateBrandRequestModel model);
        bool UpdateBrand(int id, UpdateBrandRequestModel model);
        BrandDto GetBrand(int id);
        IList<BrandDto> GetAllBrands();
        bool UpdateBrandStatus(int id, BrandStatus status);
        bool DeleteBrand(int id);

    }
}
