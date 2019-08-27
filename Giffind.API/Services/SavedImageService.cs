using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GifFind.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GifFind.API.Services
{
    public class SavedImageService : ISavedImageService
    {
        private readonly GifFindContext _context;

        public SavedImageService(GifFindContext context)
        {
            this._context = context;
        }
        public async Task DeleteImage(Guid id)
        {
            var foundImage = await GetSavedImage(id);

            if (foundImage == null)
            {
                return;
            }

            _context.Remove(foundImage);

            await this.SaveAsync();
        }

        public async Task<SavedImage> GetSavedImage(Guid id)
        {
            return await _context.SavedImages.Where(s => s.id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SavedImage>> GetSavedImages(Guid categoryId)
        {
            return await _context.SavedImages.Where(s => s.categoryid.Equals(categoryId)).ToListAsync();
        }

        public async Task SaveImage(SavedImage image)
        {
            _context.Add(image);

            await this.SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
