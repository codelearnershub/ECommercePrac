using ECommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Interfaces.IRepositories
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Update(Category category);
        Category Get(int id);
        List<Category> GetAll();
        void Delete(Category category);
        bool CategoryExists(string categoryName);
        IList<Category> GetSelectedCategories(List<int> ids);
    }
}
