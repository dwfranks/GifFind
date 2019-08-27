using System;

namespace GifFind.API.Entities
{
    public class SavedOriginalStill
    {
        public Guid id { get; set; }
        public Guid saved_imageid { get; set; }
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public SavedImage saved_image { get; set; }
    }
}
