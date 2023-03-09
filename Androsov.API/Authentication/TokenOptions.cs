namespace Androsov.Services.Authentication
{
    public class TokenOptions
    {
        public int ExpirationInMinutes { get; set; }
        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;

        public string Secret { get; set; } = null!;
    }
}