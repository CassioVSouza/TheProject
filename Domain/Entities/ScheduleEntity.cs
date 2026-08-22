using System.ComponentModel.DataAnnotations;

namespace The_Project.Domain.Entities
{
    public class ScheduleEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
