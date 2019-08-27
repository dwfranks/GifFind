using System;

namespace GifFind.API.Models
{
    public class Original : IStill, IMp4, IWebp, IDimension, IFrames, IHash
    {
        public Guid? id { get; set; }
        public Guid? saved_imageid { get; set; }
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string frames { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
        public string hash { get; set; }
    }
}
