namespace DemoMvcSdk.Models
{
    public record TodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset DueAt { get; set; }
    }
}
