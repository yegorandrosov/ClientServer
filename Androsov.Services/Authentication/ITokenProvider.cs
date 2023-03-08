namespace Androsov.Services.Authentication
{
    public interface ITokenProvider
    {
        Task<string> GetToken();
    }
}
