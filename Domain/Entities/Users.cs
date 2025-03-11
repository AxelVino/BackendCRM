namespace Domain.Entities
{
    public class Users
    {
        public int UserID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
