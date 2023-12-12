using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Todo
    {
        [Key]
        public string? Id { get; set; }

        public required string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public required bool Finished { get; set; }
    }
}