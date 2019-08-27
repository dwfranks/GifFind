using GifFind.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFind.API.Services
{
    public interface ISavedImageService
    {
        Task<IEnumerable<SavedImage>> GetSavedImages(Guid categoryId);
        Task<SavedImage> GetSavedImage(Guid id);
        Task SaveImage(SavedImage savedImage);
        Task DeleteImage(Guid id);
    }
}
