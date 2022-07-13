// dotnet add package Microsoft.IdentityModel.Tokens
// dotnet add package System.IdentityModel.Tokens.Jwt
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
namespace Zoom
{
    public class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Generate Web SDK Token...");

            // Replace with your SDK API Key
            string apiKey = "SDK_API_KEY";

            // Replace with your SDK API Secret
            string apiSecret = "SDK_API_SECRET";

            // Replace with a Meeting Number
            string meetingNumber = "MEETING_NUMBER";

            // role: 0 for participant, 1 for host
            int role = 1; 
            string token = GenerateSdkToken(apiKey, apiSecret, meetingNumber, role);
            Console.WriteLine (token);
        }
        
        //
        public static string GenerateSdkToken (string sdkKey, string sdkSecret, string meetingNumber, int role, int accessTokenValidityInMinutes = 120)
        {
            DateTime now = DateTime.UtcNow;

            // Get the current epoch timestamp
            int tsNow = (int)(now - new DateTime(1970, 1, 1)).TotalSeconds;
            int tsAccessExp = (int)(now.AddMinutes(accessTokenValidityInMinutes) - new DateTime(1970, 1, 1)).TotalSeconds;

            return CreateToken(sdkSecret, new JwtPayload
                {
                    { "sdkKey", sdkKey },
                    { "mn", meetingNumber},
                    { "role", role},
                    { "iat", tsNow },
                    { "exp", tsAccessExp },
                    { "appKey", sdkKey }
                });
        }

        public static string CreateToken(string secret, JwtPayload payload)
        {
            // Create Security key using private key above:
            // Note that latest version of JWT using Microsoft namespace instead of System
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            // Also note that securityKey length should be >256b
            // so you have to make sure that your private key has a proper length
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create a Token
            var header = new JwtHeader(credentials);

            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            // Token to String so you can use it in your client
            return handler.WriteToken(secToken);
        }
    }
}