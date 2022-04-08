using Demo1Api.Models;

namespace Demo1Api.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid id);
    }
}
