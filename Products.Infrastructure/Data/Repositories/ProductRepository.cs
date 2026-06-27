using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Infrastructure.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<Product?> GetProductWithItemsAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsWithItemsAsync()
        {
            return await _context.Products
                .Include(p => p.Items)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}