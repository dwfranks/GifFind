﻿namespace GifFind.API.Models
{
    public class DownsizedStill : IStill, IDimension
    {
        public string url { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string size { get; set; }
    }
}
