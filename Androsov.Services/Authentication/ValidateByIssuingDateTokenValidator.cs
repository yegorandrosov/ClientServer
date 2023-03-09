using Newtonsoft.Json;
using System.Text;

namespace Androsov.Services.Authentication
{
    public class ValidateByIssuingDateTokenValidator : ITokenValidator
    {
        public bool IsTokenValid(string token)
        {
            var jwtBody = token.Split('.')[1].Replace("-", "+").Replace("_", "/"); 
            switch (jwtBody.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    jwtBody += "==";
                    break;
                case 3:
                    jwtBody += "=";
                    break;
                default:
                    throw new Exception("Illegal base64 string!");
            }
            var jwtBodyDecoded = Convert.FromBase64String(jwtBody);
            var tokenBody = Encoding.UTF8.GetString(jwtBodyDecoded);

            var jObject = JsonConvert.DeserializeObject<dynamic>(tokenBody);

            var exp = long.Parse(jObject!["exp"].ToString());
            var unixTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(exp); // why 2070 year?
            var expirationDate = new DateTime(unixTimeOffset.Ticks, DateTimeKind.Utc);

            return DateTime.UtcNow + TimeSpan.FromMinutes(5) < expirationDate;
        }
    }
}
