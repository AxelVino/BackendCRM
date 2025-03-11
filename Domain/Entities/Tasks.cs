namespace Domain.Entities
{
    public class Tasks
    {
        public Guid TaskID { get; set; }
        public required string Name { get; set; }
        public required DateTime DueDate { get; set; }
        public Guid ProjectID { get; set; }
        public required Projects Projects { get; set; }
        public int AssignedTo { get; set; }
        public required Users Users { get; set; }
        public int Status { get; set; }
        public required TaskStatus TaskStatus { get; set; }
        public required DateTime CreateDate { get; set; }
        public required DateTime UpdateDate { get; set; }
    }
}
