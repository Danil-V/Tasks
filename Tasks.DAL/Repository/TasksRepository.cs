﻿using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data.EF;
using Tasks.DAL.Data.Models;
using Tasks.DAL.Interfaces;

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
            _db.Update(task);
        }

        public async Task DeleteAsync(int id) {
            var task = await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
            if (task != null)
                _db.Tasks.Remove(task);
        }
    }
}
