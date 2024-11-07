using System.ComponentModel.DataAnnotations;

namespace TM_TodoManager.Core.Entities
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

    }
}
