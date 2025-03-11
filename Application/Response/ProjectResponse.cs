namespace Application.Response
{
    public class ProjectResponse
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }
        public required ClientResponse Client { get; set; }
        public required CampaignResponse CampaignType { get; set; }
    }
}
