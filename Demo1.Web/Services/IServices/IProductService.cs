using Demo1.Web.Models;

namespace Demo1.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        Task<T> GetProductByIdAsync<T>(Guid id, string token);
        Task<T> GetProductsAsync<T>(string token);
        Task<T> CreateProductAsync<T>(ProductCreateDto productCreateDto, string token);
        Task<T> UpdateProductAsync<T>(ProductCreateDto productCreateDto, string token);
        Task<T> DeleteProductAsync<T>(Guid id, string token);

    }
}
