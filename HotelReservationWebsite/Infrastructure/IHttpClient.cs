using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelReservationWebsite.Infrastructure
{
    public interface IHttpClient
    {
        Task<IEnumerable<T>> GetListAsync<T>(string url) where T : class;
        Task<T> GetAsync<T>(string url) where T : class;
        Task PostAsync(string url, object entity);
        Task PutAsync(string url, object entity);
        Task DeleteAsync(string url);
    }
}