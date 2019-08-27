using System;

namespace GifFind.API.Models
{
    public class OriginalStill : IStill, IDimension
    {
        public Guid? id { get; set; }
        public Guid? saved_imageid { get; set; }
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
    }
}
