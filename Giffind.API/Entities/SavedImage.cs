using GifFind.API.Entities;
using System;

namespace GifFind.API.Entities
{
    public class SavedImage
    {
        public Guid id { get; set; }
        public Guid categoryid { get; set; }
        public string imageid { get; set; }
        public string title { get; set; }
        public string source_url { get; set; }
        public string orgin_url { get; set; }
    
        public SavedOriginalStill saved_original_still { get; set; }
        public SavedOriginal saved_original { get; set; }
        public SavedPreviewGif saved_previewGif { get; set; }
        public Category Category { get; set; }
    }
}
