namespace task_manager.data.Repositories.Interface
{
    public interface IRepositoryAsync<T>
    {
        Task AddAsync(T entity);
        Task<T> GetAsync(int id);
        Task<T> GetASync(string id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(string id);
        Task DeleteAsync(T entity);
        Task<bool> ExitsAsync(int id);
        Task<bool> ExitsAsync(string id);
        Task<int> SaveSync();
    }
}