using Microsoft.AspNetCore.Mvc;
using Tasks.BLL.DTO;
using Tasks.BLL.Services;
using Tasks.DAL.Data.Entity;
using Tasks.Web.Models;

namespace Tasks.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : Controller
    {
        private TasksService _tasksService;

        public TaskController(DataContext db) {
            _tasksService = new TasksService(db);
        }

        [HttpGet]
        public IActionResult CreateTask() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTaskAsync([FromForm] TaskViewModel model)
        {
            var viewTask = new TaskViewDTO();
            if (ModelState.IsValid) {
                viewTask.Id = Guid.NewGuid().GetHashCode();
                viewTask.Name = model.Name;
                viewTask.Description = model.Description;
                viewTask.Status = model.Status;

                await _tasksService.CreateTaskAsync(viewTask);

                return RedirectToAction("StartPage", "Home");
            }
            else
                ModelState.AddModelError("", "Заполните все поля");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTaskAsync(string id) {
            TaskViewDTO task = await _tasksService.ReadTaskAsync(id);
            var taskModel = new TaskViewModel();
            // Передаем данные в представление:
            taskModel.Id = task.Id;
            taskModel.Name = task.Name;
            taskModel.Description = task.Description;
            taskModel.Status = task.Status;

            return View(taskModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTaskAsync([FromForm] TaskViewModel model) {
            var viewTask = new TaskViewDTO();
            if (ModelState.IsValid) {
                viewTask.Id = model.Id;
                viewTask.Name = model.Name;
                viewTask.Description = model.Description;
                viewTask.Status = model.Status;

                await _tasksService.UpdateTaskAsync(viewTask);

                return RedirectToAction("StartPage", "Home");
            }
            else
                ModelState.AddModelError("", "Заполните все поля");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTaskAsync(string id) {
            await _tasksService.DeleteTaskAsync(id);

            return RedirectToAction("StartPage", "Home");
        }
    }
}
