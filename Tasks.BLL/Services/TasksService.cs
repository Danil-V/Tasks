using AutoMapper;
using Tasks.BLL.DTO;
using Tasks.BLL.Interfaces;
using Tasks.DAL.Repository;
using Tasks.DAL.Data.Entity;
using Tasks.DAL.Data.Models;

namespace Tasks.BLL.Services
{
    public class TasksService : ITasksService {
        public UnitOfWork unitOfWork;
        public TasksService(DataContext dataContext) {
            unitOfWork = new UnitOfWork(dataContext);
        }

        public IEnumerable<TaskDTO> ReadTasks() {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserTask, TaskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserTask>, List<TaskDTO>>(unitOfWork.Tasks.GetAll());
        }

        public IEnumerable<StatusDTO> ReadStatuses() {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<StatusTask, StatusDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<StatusTask>, List<StatusDTO>>(unitOfWork.Statuses.GetAll());
        }

        public async Task CreateTaskAsync(TaskViewDTO viewTaskDTO) {
            if (viewTaskDTO != null) {
                var status = await unitOfWork.Statuses.GetAsync(viewTaskDTO.Status);

                var task = new UserTask {
                    Id = viewTaskDTO.Id,
                    Name = viewTaskDTO.Name,
                    Description = viewTaskDTO.Description,
                    Date = DateTime.Now,
                    StatusId = status.Id
                };

                await unitOfWork.Tasks.CreateAsync(task);
                await unitOfWork.SaveAsync();
            }
        }

        public async Task<TaskViewDTO> ReadTaskAsync(string item) {
            var viewTask = new TaskViewDTO();

            // Формируем нужные нам данные для передачи в представление:
            var task = await unitOfWork.Tasks.GetAsync(item);
            var status = await unitOfWork.Statuses.GetAsync(task.StatusId.ToString());

            viewTask.Id = task.Id;
            viewTask.Name = task.Name;
            viewTask.Description = task.Description;
            viewTask.Date = task.Date;
            viewTask.Status = status.Name;

            return viewTask;
        }

        public async Task UpdateTaskAsync(TaskViewDTO viewTaskDTO) {
            var status = await unitOfWork.Statuses.GetAsync(viewTaskDTO.Status);
            var task = await unitOfWork.Tasks.GetAsync(viewTaskDTO.Id.ToString());
            var updateTask = new UserTask {
                Id = task.Id,
                Name = viewTaskDTO.Name,
                Description = viewTaskDTO.Description,
                Date = task.Date,
                StatusId = status.Id
            };

            await unitOfWork.Tasks.UpdateAsync(updateTask);
            await unitOfWork.SaveAsync();
        }

        public async Task DeleteTaskAsync(string id) {
            UserTask task = await unitOfWork.Tasks.GetAsync(id);
            
            await unitOfWork.Tasks.DeleteAsync(task.Id);
            await unitOfWork.SaveAsync();
        }
    }
}
