using Products.Domain.Entities;

namespace Products.Infrastructure.Data.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetProductWithItemsAsync(int id);

        Task<IEnumerable<Product>> GetAllProductsWithItemsAsync();
    }
}