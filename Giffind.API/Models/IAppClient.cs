using System.Threading.Tasks;

namespace GifFind.API.Models
{
    public interface IAppClient
    {
        Task<RootObject> SearchAsync(string query, int limit = 100, int offset = 0);
    }
}
