using System;
using System.Collections.Generic;

namespace GifFind.API.Entities
{
    public class Category
    {
        public Guid CategoryID { get; set; }
        public Guid UserID { get; set; }
        public string CategoryName { get; set; }

        public AppUser User { get; set; }
        public ICollection<SavedImage> SavedImages { get; set; } = new HashSet<SavedImage>();
    }
}
