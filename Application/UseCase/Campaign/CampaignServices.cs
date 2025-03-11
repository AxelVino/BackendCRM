using Application.Interfaces;
using Application.Response;
using Application.Interfaces.IMappers;
using Domain.Entities;
using Application.Exceptions;

namespace Application.UseCase.Campaign
{
    public class CampaignServices : ICampaignService
    {
        private readonly ICampaignQuery _query;
        private readonly ICampaignMapper _mapper;

        public CampaignServices(ICampaignQuery query, ICampaignMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<CampaignResponse> GetById(int id)
        {
            var campaign = await _query.GetCampaignById(id);

            if (campaign == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            return await _mapper.GetCampaignResponse(campaign);
        }

        public async Task<CampaignTypes> GetCampaignById(int id)
        {
            var campaign = await _query.GetCampaignById(id);

            if (campaign == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            return campaign;
        }

        public async Task<List<CampaignResponse>> GetCampaignList()
        {
            return await _mapper.GetAllCampaignResponse(await _query.GetCampaignList());
        }
    }
}
