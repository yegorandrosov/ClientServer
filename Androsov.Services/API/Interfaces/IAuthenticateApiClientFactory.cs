namespace Androsov.Services.API.Interfaces
{
    public interface IAuthenticateApiClientFactory
    {
        IAuthenticatedApiClient this[string username] { get; }
    }
}