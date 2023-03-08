namespace Androsov.Services.Authentication
{
    public interface ITokenValidator
    {
        bool IsTokenValid(string token);
    }
}
