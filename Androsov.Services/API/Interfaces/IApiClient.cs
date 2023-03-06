namespace Androsov.Services.API.Interfaces
{
    /// <summary>
    /// A single entry point for the API
    /// </summary>
    public interface IApiClient
    {
        IAuthenticatedApiClient Me { get; }
        IAuthenticateApiClientFactory Users { get; }
    }

    public interface IAuthenticatedApiClient
    {
        IMessageApiClient Messages { get; }
        HttpClient GetHttpClient();
    }
}
