using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IServices
{
    public interface ICategoryService
    {
        bool AddCategory(CreateCategoryRequestModel model);
        bool UpdateCategory(int id, UpdateCategoryRequestModel model);
        CategoryDto GetCategory(int id);
        IList<CategoryDto> GetAllCategories();
       
        bool DeleteCategory(int id);
    }
}
