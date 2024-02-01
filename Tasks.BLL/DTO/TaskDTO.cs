﻿namespace Tasks.BLL.DTO
{
    public class TaskDTO {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }

        public int StatusId { get; set; }
    }
}
