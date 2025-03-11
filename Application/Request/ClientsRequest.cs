namespace Application.Request
{
    public class ClientsRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Company { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
    }
}
