using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GifFind.API.Models
{
    public interface IDimension
    {
        string height { get; set; }
        string width { get; set; }
    }
}
