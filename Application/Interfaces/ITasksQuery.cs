namespace Application.Interfaces
{
    public interface ITasksQuery
    {
        Task<List<Domain.Entities.Tasks>> GetTasksList(Guid projectid);
        Task<Domain.Entities.Tasks> GetTaskById(Guid taskId);
    }
}
    