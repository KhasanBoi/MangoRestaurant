using Mango.Web.Dtos;
using Mango.Web.Models;

namespace Mango.Web.Services.IServices.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }

        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
