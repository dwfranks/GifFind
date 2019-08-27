using GifFind.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GifFind.Service
{
    public interface IAppClient
    {
        IEnumerable<GifPackage> Search(string topic);
    }
}
