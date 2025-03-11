namespace Domain.Entities
{
    public class Interactions
    {
        public Guid InteractionID { get; set; }
        public required Guid ProjectID { get; set; }
        public required Projects Projects { get; set; }
        public required int InteractionType { get; set; }
        public required InteractionTypes InteractionTypes { get; set; }
        public required DateTime Date { get; set; }
        public required string Notes { get; set; }

    }
}
