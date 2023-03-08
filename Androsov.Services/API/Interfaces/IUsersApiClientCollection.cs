namespace Androsov.Services.API.Interfaces
{
    public interface IUsersApiClientCollection
    {
        IUsersApiClient this[string username] { get; }
    }
}