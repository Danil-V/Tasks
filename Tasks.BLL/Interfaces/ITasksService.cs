using Tasks.BLL.DTO;

namespace Tasks.BLL.Interfaces
{
    public interface ITasksService {
        IEnumerable<TaskDTO> ReadTasks();
        IEnumerable<StatusDTO> ReadStatuses();

        Task CreateTaskAsync(TaskViewDTO viewOrder);
        Task<TaskViewDTO> ReadTaskAsync(string item);
        Task UpdateTaskAsync(TaskViewDTO viewOrder);
        Task DeleteTaskAsync(string item);
    }
}
