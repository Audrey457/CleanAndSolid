namespace CleanAndSolid.Application.Contracts.Persistance
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> GetAsync(T entity);
        Task<T> GetByIdAsync(int id);
    }
}
