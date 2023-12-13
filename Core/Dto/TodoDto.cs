namespace Core.Dto
{
    public class TodoDto
    {
        public string? Id { get; set; }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public string? FormattedDate { get; set; }

        public bool? Finished { get; set; } = false;
    }
}