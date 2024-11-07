namespace TM_TodoManager.Application.DTOs
{
    public class BaseTaskDto
    {
        public required string Name { get; set; }

        public DateTime? DueDate { get; set; }
    }
}