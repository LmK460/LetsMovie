namespace LetsMovie.Models
{
    public class User
    {
        public Role Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public People People { get; set; }
    }
}
