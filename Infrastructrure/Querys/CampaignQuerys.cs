using Domain.Entities;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Exceptions;

namespace Infrastructrure.Querys
{
    public class CampaignQuerys:ICampaignQuery
    {
        private readonly CrmDbContext _context;

        public CampaignQuerys(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<CampaignTypes> GetCampaignById(int id)
        {

            return await _context.CampaignTypes
            .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<CampaignTypes>> GetCampaignList()
        {
            return await _context.CampaignTypes.ToListAsync();
        }
    }
}
