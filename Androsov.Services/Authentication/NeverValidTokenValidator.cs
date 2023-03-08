namespace Androsov.Services.Authentication
{
    public class NeverValidTokenValidator : ITokenValidator
    {
        public bool IsTokenValid(string token) => false;
    }
}
