using API.Models;

namespace LetsMovie.Models
{
    public class User
    {
        public string Role { get; set; }
        public string UserName { get; set; }
        public People People { get; set; }

        public Token? Token { get; set; }

    }
}
