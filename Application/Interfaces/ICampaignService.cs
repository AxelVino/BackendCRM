using Application.Response;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface ICampaignService
    {
        Task<List<CampaignResponse>> GetCampaignList();
        Task<CampaignResponse> GetById(int id);
        Task<CampaignTypes> GetCampaignById(int id);
    }
}
