namespace Androsov.Services.API.Models
{
    public class BasicApiClientAuthentication
    {
        public BasicApiClientAuthentication(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Password { get; set; }
        public string Username { get; set; }

    }
}
