namespace Application.Interfaces
{
    public interface ITaskStatusQuerys
    {
        Task<List<Domain.Entities.TaskStatus>> GetTaskStatusList();
        Task<Domain.Entities.TaskStatus> GetTaskStatusById(int statusId);
    }
}
