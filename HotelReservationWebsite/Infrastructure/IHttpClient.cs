using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationWebsite.Infrastructure
{
    public interface IHttpClient
    {
        Task<IEnumerable<T>> GetListAsync<T>(string url) where T : class;
        Task<T> GetAsync<T>(string url) where T : class;
        Task<T> PostAsync<T>(string url, T entity) where T : class;
        Task<T> PutAsync<T>(string url, T entity) where T : class;
        Task DeleteAsync(string url);
    }
}