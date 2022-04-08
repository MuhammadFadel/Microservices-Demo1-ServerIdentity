using Demo1Api.Models;
using Demo1Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace Demo1Api.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Product> GetProductById(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
