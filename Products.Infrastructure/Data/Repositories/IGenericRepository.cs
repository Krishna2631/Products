using System.Linq.Expressions;

namespace Products.Infrastructure.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Get all records
        Task<IEnumerable<T>> GetAllAsync();

        // Get record by Id
        Task<T?> GetByIdAsync(int id);

        // Find records using a condition
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // Add a new record
        Task AddAsync(T entity);

        // Update an existing record
        void Update(T entity);

        // Delete a record
        void Delete(T entity);

        // Check if record exists
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }
}