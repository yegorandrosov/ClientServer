namespace Androsov.Services.API.Interfaces
{
    public interface IUsersApiClientFactory
    {
        IUsersApiClient Create(string username);
    }
}