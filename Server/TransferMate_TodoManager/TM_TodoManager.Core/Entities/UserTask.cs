using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace TM_TodoManager.Core.Entities
{
    public class UserTask
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        public int StatusId { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        [Required]
        public Status? Status { get; set; }
    }
}