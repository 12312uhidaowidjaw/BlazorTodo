using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class Todo
    {
        [Key]
        public string? Id { get; set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public bool Finished { get; set; }
    }
}