using Tasks.DAL.Data.EF;
using Tasks.DAL.Data.Models;
using Tasks.DAL.Interfaces;

namespace Tasks.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork { 
        private DataContext _db;
        private TasksRepository _tasksRepository;
        private StatusesRepository _statusesRepository;

        public UnitOfWork(DataContext db) {
            _db = db;
        }

        public IRepository<UserTask> Tasks {
            get {
                if (_tasksRepository == null)
                    _tasksRepository = new TasksRepository(_db);
                return _tasksRepository;
            }
        }

        public IRepository<StatusTask> Statuses {
            get {
                if (_statusesRepository == null)
                    _statusesRepository = new StatusesRepository(_db);
                return _statusesRepository;
            }
        }

        public async Task SaveAsync() {
            try {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing) {
            if (!disposed) {
                if (disposing) {
                    _db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
