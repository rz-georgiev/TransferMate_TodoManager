namespace TM_TodoManager.Domain.Entities
{
    public class UserTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StatusId { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
