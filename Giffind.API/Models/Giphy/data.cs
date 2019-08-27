namespace GifFind.API.Models
{
    public class Data
    {
        public string type { get; set; }
        public string id { get; set; }
        public string slug { get; set; }
        public string url { get; set; }
        public string bitly_gif_url { get; set; }
        public string bitly_url { get; set; }
        public string embed_url { get; set; }
        public string username { get; set; }
        public string source { get; set; }
        public string rating { get; set; }
        public string content_url { get; set; }
        public string source_tld { get; set; }
        public string source_post_url { get; set; }
        public int is_sticker { get; set; }
        public string import_datetime { get; set; }
        public string trending_datetime { get; set; }
        public ImagePackage images { get; set; }
        public string title { get; set; }
    }
}
