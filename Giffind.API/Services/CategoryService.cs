using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GifFind.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GifFind.API.Services
{
    public class CategoryService : ICategoryService
    {
        GifFindContext _context;

        public CategoryService(GifFindContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Add(category);

            var added = await SaveAsync();

            if (added)
            {
                return category;
            } else
            {
                return null;
            }

        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var categoryToDelete = await this.GetCategoryAsync(id);

            if (categoryToDelete == null)
            {
                return false; // Could not find specified category
            }

            _context.Remove(categoryToDelete);

            return await SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(Guid userId)
        {
            return await _context.Categories
                                 .Include(c => c.SavedImages)
                                    .ThenInclude(c => c.saved_original)
                                 .Include(c => c.SavedImages)
                                    .ThenInclude(c => c.saved_original_still)
                                .Include(c => c.SavedImages)
                                    .ThenInclude(c => c.saved_previewGif)
                                 .Where(c => c.UserID.Equals(userId)).ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(Guid id)
        {
            return await _context.Categories.Where(c => c.CategoryID.Equals(id)).FirstOrDefaultAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
