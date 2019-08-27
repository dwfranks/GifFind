using GifFind.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFind.API.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(Guid userID);
        Task<Category> GetCategoryAsync(Guid id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(Guid id);

    }
}
