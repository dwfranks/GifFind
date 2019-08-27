using System.Collections.Generic;

namespace GifFind.API.Models.DTO
{
    public class GifPackage
    {
        public IEnumerable<GifImage> gifImages { get; set; }
        public Pagination pagination { get; set; }
    }
}
