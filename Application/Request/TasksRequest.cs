namespace Application.Request
{
    public class TasksRequest
    {
        public required string Name { get; set; }
        public required DateTime DueDate { get; set; }
        public required int User {  get; set; }
        public required int Status { get; set; }
    }
}
