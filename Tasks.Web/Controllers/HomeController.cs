using Microsoft.AspNetCore.Mvc;
using Tasks.BLL.Services;
using Tasks.DAL.Data.Entity;


namespace Tasks.Web.Controllers
{
    public class HomeController : Controller {
        private TasksService _tasksService;

        public HomeController(DataContext db) {
            _tasksService = new TasksService(db);
        }

        [HttpGet]
        public async Task<IActionResult> StartPageAsync() {
            var allTasks = _tasksService.ReadTasks();
            var tasks = allTasks.OrderBy(t => t.Date);
            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> StartPageAsync(string statusId) {
            var allTasks = _tasksService.ReadTasks();

            if (statusId != null) {
                int id = int.Parse(statusId);
                var tasks = allTasks.Where(t => t.StatusId == id);
                tasks = tasks.OrderBy(t => t.Date);
                return View(tasks);
            }
            else {
                allTasks = allTasks.OrderBy(t => t.Date);
                return View(allTasks);
            }
        }
    }
}
