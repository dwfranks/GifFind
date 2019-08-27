using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifFind.API.Models.DTO
{
    public class GifImage
    {
        public Guid? id { get; set; }
        public Guid? categoryid { get; set; }
        public string imageid { get; set; }
        public string title { get; set; }
        public string source_url { get; set; }
        public string orgin_url { get; set; }
    
        public OriginalStill original_still { get; set; }
        public Original original { get; set; }
        public PreviewGif previewGif { get; set; }
    }
}
