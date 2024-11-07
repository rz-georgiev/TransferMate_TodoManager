namespace TM_TodoManager.Core.Entities
{
    public class UserTask
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int StatusId { get; set; }

        public DateTime? DueDate { get; set; }

        public Status? Status { get; set; }
    }
}