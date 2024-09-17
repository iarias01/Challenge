namespace BackendChallenge.Models
{
    public class FormRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Comment { get; set; }
        public IFormFile? File { get; set; }
    }
}
