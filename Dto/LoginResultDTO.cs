namespace API.Models
{
    public class LoginResultDTO
    {
        public string? Message { get; set; }
        public bool Autenticated { get; set; }
        public string? Created { get; set; }
        public string? Expiration { get; set; }
        public string? AccessToken { get; set; }
        public string? Role { get; set; }
    }
}
