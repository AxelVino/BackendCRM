using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientsQuery
    {
        Task <List<Clients>> GetListClients();
        Task <Clients> GetClient(int idClient);
    }
}
