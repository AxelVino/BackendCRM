using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICampaignQuery
    {
        Task<List<CampaignTypes>> GetCampaignList();
        Task<CampaignTypes> GetCampaignById(int id);
    }
}
