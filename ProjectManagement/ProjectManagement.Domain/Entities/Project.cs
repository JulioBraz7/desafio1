namespace ProjectManagement.Domain.Entities {
    public class Project {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
