namespace Androsov.Services.API.Interfaces
{
    public interface IApiClient
    {
        IUsersApiClient Me { get; }
        IUsersApiClientCollection Users { get; }
    }
}
