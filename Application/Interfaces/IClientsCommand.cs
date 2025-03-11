using Domain.Entities;

namespace Application.Interfaces
{
    public interface IClientsCommand
    {
        Task InsertClients(Clients client);
    }
}
