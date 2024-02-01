﻿using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data.EF;
using Tasks.DAL.Data.Models;
using Tasks.DAL.Interfaces;

namespace Tasks.DAL.Repository
{
    public class StatusesRepository : IRepository<StatusTask> {
        private DataContext _db;

        public StatusesRepository(DataContext db) {
            _db = db;
        }

        public IEnumerable<StatusTask> GetAll() {
            return _db.Statuses;
        }

        public async Task<StatusTask> GetAsync(string item) {
            bool result = int.TryParse(item, out var id);

            if (result == true)
                return await _db.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            else
                return await _db.Statuses.FirstOrDefaultAsync(x => x.Name == item);
        }

        public async Task CreateAsync(StatusTask status) {
            _db.Statuses.Add(status);
        }

        public async Task UpdateAsync(StatusTask status) {
            _db.Update(status);
        }

        public async Task DeleteAsync(int id) {
            var status = await _db.Statuses.FirstOrDefaultAsync(x => x.Id == id);
            if (status != null)
                _db.Statuses.Remove(status);
        }
    }
}
