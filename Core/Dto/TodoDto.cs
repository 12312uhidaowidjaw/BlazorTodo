namespace Core.Dto
{
    public class TodoDto
    {
        public string? Id { get; set; }

        public required string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public bool? Finished { get; set; } = false;
    }
}