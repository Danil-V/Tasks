namespace Tasks.DAL.Data.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }

        public int StatusId { get; set; }
        public StatusTask? Status { get; set; }
    }
}
