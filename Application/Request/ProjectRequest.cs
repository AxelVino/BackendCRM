namespace Application.Request
{
    public class ProjectRequest
    {
        public required string Name { get; set; }
        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }
        public required int CampaignType { get; set; }
        public required int Client { get; set; }
    }
}
