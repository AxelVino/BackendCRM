using Application.Request;
using Application.Response;
using Domain.Entities;
namespace Application.Interfaces
{
    public interface IClientsService
    {
        Task<ClientResponse> CreateClient(ClientsRequest request);
        Task<ClientResponse> GetById(int clientId);
        Task<Clients> GetClientById(int clientId); 
        Task<List <ClientResponse>> GetClients();
    }
}
