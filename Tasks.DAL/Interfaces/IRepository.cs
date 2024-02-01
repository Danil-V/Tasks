namespace Tasks.DAL.Interfaces
{
    public interface IRepository<T> where T : class {
        IEnumerable<T> GetAll();
        Task<T> GetAsync(string item);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
    }
}
