namespace GifFind.API.Models
{
    public class FixedWidthDownsampled : IStill, IDimension
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
        public string webp { get; set; }
        public string webp_size { get; set; }
    }
}
