namespace Domain.Entities
{
    public class Projects
    {
        public Guid ProjectID { get; set; }
        public required string ProjectName { get; set; }
        public required int CampaignType { get; set; }
        public required CampaignTypes CampaignTypes { get; set; }
        public required int ClientID { get; set; }
        public required Clients Clients { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required DateTime CreateDate { get; set; }
        public required DateTime UpdateDate { get; set; }
        public required List<Tasks> Tasks { get; set; }
        public required List<Interactions> Interactions { get; set; }

    }
}
