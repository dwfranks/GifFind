using System;

namespace GifFind.API.Models.DTO
{
    public class SaveImageForGet
    {
        public Guid SavedImageID { get; set; }
        public string SourceID { get; set; }
        public Guid CategoryID { get; set; }
    }
}
