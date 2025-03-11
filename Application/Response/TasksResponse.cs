namespace Application.Response
{
    public class TasksResponse
    {
        public required Guid Id {  get; set; }
        public required string Name { get; set; }
        public required DateTime DueDate { get; set; }

        public required Guid ProjectId  { get; set; }
        public required TaskStatusResponse Status { get; set; }
        public required UserResponse UserAssigned { get; set; }
    }
}
