using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ICampaignMapper
    {
        Task<CampaignResponse> GetCampaignResponse(CampaignTypes campaign);
        Task<List<CampaignResponse>> GetAllCampaignResponse(List<CampaignTypes> campaign);
    }
}
