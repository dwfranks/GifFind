namespace GifFind.API.Models
{
    public class DownsizedSmall : IMp4, IDimension
    {
        public string width { get; set; }
        public string height { get; set; }
        public string mp4 { get; set; }
        public string mp4_size { get; set; }
    }
}
