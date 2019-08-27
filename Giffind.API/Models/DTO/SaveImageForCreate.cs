using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFind.API.Models.DTO
{
    public class SaveImageForCreate
    {
        public Guid SavedImageID { get; set; }
        public string SourceID { get; set; }
        public Guid CategoryID { get; set; }
    }
}
