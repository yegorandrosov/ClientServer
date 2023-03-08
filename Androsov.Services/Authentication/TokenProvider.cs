using Androsov.Services.API.Interfaces;

namespace Androsov.Services.Authentication
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IAccountApiClient accountApiClient;
        private readonly ITokenValidator tokenValidator;
        private string? token;

        public TokenProvider(IAccountApiClient accountApiClient, ITokenValidator tokenValidator)
        {
            this.accountApiClient = accountApiClient;
            this.tokenValidator = tokenValidator;
        }

        public async Task<string> GetToken()
        {
            if (token == null || tokenValidator.IsTokenValid(token) == false)
            {
                var authResponse = await accountApiClient.Login();
                token = authResponse.Token;
            }

            return token;
        }
    }
}
