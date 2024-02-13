using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Interfaces;
using Tasks.DAL.Data.Entity;
using Tasks.DAL.Data.Models;

namespace Tasks.DAL.Repository
{
    public class TasksRepository : IRepository<UserTask> {
        private DataContext _db;

        public TasksRepository(DataContext db) {
            _db = db;
        }

        public IEnumerable<UserTask> GetAll() {
            return _db.Tasks;
        }

        public async Task<UserTask> GetAsync(string item) {
            bool result = int.TryParse(item, out var id);

            if (result == true)
                return await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            else
                return await _db.Tasks.FirstOrDefaultAsync(x => x.Name == item);
        }

        public async Task CreateAsync(UserTask task) {
            _db.Tasks.Add(task);
        }

        public async Task UpdateAsync(UserTask task) {
            UserTask userTask = _db.Tasks.FirstOrDefault(x => x.Id == task.Id);
            userTask.Name = task.Name;
            userTask.Description = task.Description;
            userTask.Date = task.Date;
            userTask.StatusId = task.StatusId;
            _db.Update(userTask);
        }

        public async Task DeleteAsync(int id) {
            
            var task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task != null)
                _db.Tasks.Remove(task);
        }
    }
}
