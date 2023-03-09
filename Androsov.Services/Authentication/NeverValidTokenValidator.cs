namespace Androsov.Services.Authentication
{
    public class NeverValidTokenValidator : ITokenValidator
    {
        public bool IsTokenValid(string token) => false;
    }

    public class ValidateByIssuingDateTokenValidator : ITokenValidator
    {
        public bool IsTokenValid(string token)
        {
            var jwtBody = token.Substring(token.IndexOf('.'), token.Length - token.LastIndexOf('.'));

            return false;
        }
    }
}
