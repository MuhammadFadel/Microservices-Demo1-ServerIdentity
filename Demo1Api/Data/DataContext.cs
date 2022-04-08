using Demo1Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
