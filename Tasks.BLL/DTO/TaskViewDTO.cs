namespace Tasks.BLL.DTO
{
    public class TaskViewDTO {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
    }
}
