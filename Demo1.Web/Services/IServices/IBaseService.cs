using Demo1.Web.Models;

namespace Demo1.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto _responseDto { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
