using Products.Infrastructure.Data.Repositories;

namespace Products.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }

        Task<int> SaveChangesAsync();
    }
}