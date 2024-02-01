namespace Tasks.DAL.Data.Models
{
    public class StatusTask {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<UserTask> Tasks { get; set; }
        public StatusTask() {
            Tasks = new List<UserTask>();
        }
    }
}
