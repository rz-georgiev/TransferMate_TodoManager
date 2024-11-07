namespace TM_TodoManager.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StatusId { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
