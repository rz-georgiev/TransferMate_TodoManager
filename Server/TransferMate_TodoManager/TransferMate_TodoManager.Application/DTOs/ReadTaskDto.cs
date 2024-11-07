namespace TM_TodoManager.Application.DTOs
{
    public class ReadTaskDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DueDate { get; set; }

        public int StatusId { get; set; }
    }
}