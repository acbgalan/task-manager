namespace task_manager.data.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T GetValue(int id);
        T GetValue(string id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(int id);
        void Delete(string id);
        void Delete(T entity);
        bool Exits(int id);
        bool Exits(string id);
        int Save();
    }
}