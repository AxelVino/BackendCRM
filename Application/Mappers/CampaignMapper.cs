using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class CampaignMapper : ICampaignMapper
    {
        public Task<List<CampaignResponse>> GetAllCampaignResponse(List<CampaignTypes> campaign)
        {
            List<CampaignResponse> lista = new List<CampaignResponse>();
            foreach (var c in campaign)
            {
                var response = new CampaignResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }

        public Task<CampaignResponse> GetCampaignResponse(CampaignTypes campaign)
        {
            var response = new CampaignResponse
            {
                Id = campaign.Id,
                Name = campaign.Name,
            };
            return Task.FromResult(response);
        }
    }
}
