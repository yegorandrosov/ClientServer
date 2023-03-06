namespace Androsov.Services.API.Interfaces
{
    public interface IUsersApiClientFactory
    {
        IUsersApiClient this[string username] { get; }
    }
}