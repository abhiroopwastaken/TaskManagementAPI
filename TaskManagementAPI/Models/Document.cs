namespace TaskManagementAPI.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string? FilePath { get; set; }
        public int TaskId { get; set; }
        public Task? Task { get; set; }
    }
}
