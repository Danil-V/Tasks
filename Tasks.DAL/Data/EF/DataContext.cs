﻿using Microsoft.EntityFrameworkCore;
using Tasks.DAL.Data.Models;

namespace Tasks.DAL.Data.EF
{
    public class DataContext : DbContext {
        public DbSet<UserTask>? Tasks => Set<UserTask>();
        public DbSet<StatusTask>? Statuses => Set<StatusTask>();

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            try {
                bool isCreated = Database.EnsureCreated();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex); }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            StatusTask taskCreated = new StatusTask { Id = 1, Name = "Создана" };
            StatusTask taskAtWork = new StatusTask { Id = 2, Name = "В работе" };
            StatusTask taskComplited = new StatusTask { Id = 3, Name = "Завершена" };
            modelBuilder.Entity<StatusTask>().HasData(new StatusTask[] { taskCreated, taskAtWork, taskComplited });

            modelBuilder.Entity<UserTask>().HasData(
                    new UserTask { Id = 1, Name = "Моя первая задача", Description = "May the force be with you", Date = DateTime.Now, StatusId = 2 });
        }
    }
}
