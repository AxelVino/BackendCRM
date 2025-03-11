namespace Application.Response
{
    public class InteractionResponse
    {
        public required Guid Id { get; set; }
        public required string Notes { get; set; }
        public required DateTime Date { get; set; }
        public required Guid ProjectId { get; set; }
        public required InteractionTypeResponse InteractionType { get; set; }
    }
}
