using System.Collections.Generic;

namespace GifFind.API.Models
{
    public class RootObject
    {
        public IEnumerable<Data> data { get; set; }
        public Pagination pagination { get; set; }
        public Meta meta { get; set; }
    }
}
