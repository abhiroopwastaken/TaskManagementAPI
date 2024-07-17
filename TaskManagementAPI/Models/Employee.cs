namespace TaskManagementAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public ICollection<Task>? Tasks { get; set; }
    }
}
