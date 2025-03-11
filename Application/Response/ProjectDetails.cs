namespace Application.Response
{
    public class ProjectDetails
    {
        public required ProjectResponse Data { get; set; }

        public required List<InteractionResponse> Interaction { get; set; }

        public required List<TasksResponse> Tasks { get; set; }
    }
}
