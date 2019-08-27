using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFind.API.Models.DTO
{
    public class CategoryForGet
    {
        public Guid CategoryID { get; set; }
        public Guid UserID { get; set; }
        public string CategoryName { get; set; }

        public IEnumerable<GifImage> SavedImages { get; set; }

    }
}
