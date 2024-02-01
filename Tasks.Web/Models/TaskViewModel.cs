using System.ComponentModel.DataAnnotations;

namespace Tasks.Web.Models
{
    public class TaskViewModel {
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано название задачи")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Не указано описание задачи")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Не выбран статус задачи")]
        public string? Status { get; set; }
    }
}