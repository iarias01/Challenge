namespace BackendChallenge.Models
{
    public class Form
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Comment { get; set; }
        public byte[]? File { get; set; } 
    }
}
