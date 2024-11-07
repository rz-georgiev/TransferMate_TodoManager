namespace TM_TodoManager.Application.DTOs
{
    public class UpdateTaskDto : BaseTaskDto
    {
        public int Id { get; set; }

        public int StatusId { get; set; }
    }
}