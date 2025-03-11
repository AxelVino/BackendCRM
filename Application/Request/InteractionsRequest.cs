namespace Application.Request
{
    public class InteractionsRequest
    {
        public required string Notes {  get; set; }
        public required DateTime Date { get; set; }
        public required int InteractionType { get; set; }
    }
}
