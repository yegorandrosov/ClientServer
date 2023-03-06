namespace Androsov.Services.API.Interfaces
{
    /// <summary>
    /// A single entry point for the API
    /// </summary>
    public interface IApiClient
    {
        IUsersApiClient Me { get; }
        IUsersApiClientFactory Users { get; }
        HttpClient CreateHttpClient();
    }
}
