using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifFind.API.Models.Giphy
{
    public class Giphy
    {
        public IEnumerable<Data> data { get; set; }
    }
}
