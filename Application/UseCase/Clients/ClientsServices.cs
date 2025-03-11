using Application.Interfaces;
using Application.Exceptions;
using Application.Response;
using Application.Request;
using Application.Interfaces.IMappers;

namespace Application.UseCase.Clients
{
    public class ClientsServices : IClientsService
    {
        private readonly IClientsCommand _command;
        private readonly IClientsQuery _query;
        private readonly IClientsMapper _mapper;
        public ClientsServices(IClientsCommand command, IClientsQuery query, IClientsMapper mapper)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
        }

        public async Task<ClientResponse> GetById(int clientId)
        {
            var client = await _query.GetClient(clientId);
            if (client == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            return await _mapper.GetClientResponse(client);
        }
        public async Task<ClientResponse> CreateClient(ClientsRequest request)
        {
                CheckClientRequestData(request);
                var client = new Domain.Entities.Clients
                {
                    Name = request.Name,
                    Email = request.Email,
                    Company = request.Company,
                    Phone = request.Phone,
                    Address = request.Address,
                    CreateDate = DateTime.Now,
                };
                await _command.InsertClients(client);
                return await _mapper.GetClientResponse(client);
        }
        public async Task<List<ClientResponse>> GetClients()
        {
            return await _mapper.GetAllClientsResponse(await _query.GetListClients());
        }
        public async Task<Domain.Entities.Clients> GetClientById(int clientId)
        {
            var client = await _query.GetClient(clientId);
            if (client == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            return client;
            
        }
        private static bool CheckClientRequestData(ClientsRequest request)
        {
            if (!request.Email.Contains('@'))
            {
                throw new ExceptionBadRequest("¡Please, use a valid mail!");
            }
            if(string.IsNullOrWhiteSpace(request.Name)
                || string.IsNullOrWhiteSpace(request.Address)
                || string.IsNullOrWhiteSpace(request.Company)
                || string.IsNullOrWhiteSpace(request.Phone))
            {
                throw new ExceptionBadRequest("¡Please, you cannot enter only a space or null!");
            }
            return true;
        }

    }
}
