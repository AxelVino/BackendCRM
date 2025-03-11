using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class ClientMapper : IClientsMapper
    {
        public Task<List<ClientResponse>> GetAllClientsResponse(List<Clients> clients)
        {
            List<ClientResponse> lista = new List<ClientResponse>();
            foreach (var c in clients)
            {
                var response = new ClientResponse
                {
                    Id = c.ClientID,
                    Name = c.Name,
                    Email = c.Email,
                    Company =  c.Company,
                    Phone  = c.Phone,
                    Address = c.Address,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }

        public Task<ClientResponse> GetClientResponse(Clients client)
        {
            var response = new ClientResponse
            {
                Id = client.ClientID,
                Name = client.Name,
                Email = client.Email,
                Company = client.Company,
                Phone = client.Phone,
                Address = client.Address,
            };
            return Task.FromResult(response);
        }
    }
}
