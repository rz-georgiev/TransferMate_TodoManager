namespace TM_TodoManager.Application.DTOs
{
    public class ReadTaskDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime? DueDate { get; set; }

        public int StatusId { get; set; }

        public required string StatusName { get; set; }
    }
}