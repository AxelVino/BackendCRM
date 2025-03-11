
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IClientsMapper
    {
        Task<ClientResponse> GetClientResponse(Clients client);
        Task<List<ClientResponse>> GetAllClientsResponse(List<Clients> clients);
    }
}
