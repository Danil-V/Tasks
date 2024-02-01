using Tasks.DAL.Data.Models;

namespace Tasks.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable {
        IRepository<UserTask> Tasks { get; }
        IRepository<StatusTask> Statuses { get; }
        Task SaveAsync();
    }
}
