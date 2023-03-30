using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Spefy.Core.SpotifyProvider.SpotifyServer;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using Swan.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Spefy.Core.Services.Auth
{
    internal class AuthorizeService : IAuthorizeService
    {
        private readonly ISpotifyServerProvider _authServer;
        private readonly IConfiguration _config;

        public AuthorizeService(ISpotifyServerProvider authServer, IConfiguration config)
        {
            _authServer = authServer;
            _config = config;
        }
        public void Authorize()
        {

            _authServer.AuthorizationCodeReceived += OnAuthorizationCodeReceived;
            _authServer.Start();

            var request = new LoginRequest(_authServer.BaseUri, _config.GetValue<string>("SpotifyServer:ClientId"), LoginRequest.ResponseType.Code)
            {
                Scope = new List<string>
                {
                    Scopes.UserReadEmail,
                    Scopes.PlaylistModifyPrivate,
                    Scopes.PlaylistModifyPublic,
                    Scopes.PlaylistReadPrivate,
                    Scopes.UserReadRecentlyPlayed,
                    Scopes.UserTopRead
                },
                ShowDialog = true
            };

            try
            {
                BrowserUtil.Open(request.ToUri());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to open URL, manually open: {0}", _authServer.BaseUri);
            }

            Console.ReadLine();
            
            
        }

        public string GetToken()
        {
            using (FileStream fs = new FileStream(@"..\..\..\..\Spefy.Core\Files\Token.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadLine()?? "";
                }

            }
        }

        public string GetTokenType()
        {
            using (FileStream fs = new FileStream(@"..\..\..\..\Spefy.Core\Files\Token.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var line = sr.ReadLine() ?? "";
                    line = sr.ReadLine() ?? "";
                    return line;
                }

            }
        }

        private async Task OnAuthorizationCodeReceived(object sender, AuthorizationCodeResponse response)
        {
            await _authServer.Stop();
            var config = SpotifyClientConfig.CreateDefault();
            AuthorizationCodeTokenResponse token = await new OAuthClient(config).RequestToken(
              new AuthorizationCodeTokenRequest(
                   _config.GetValue<string>("SpotifyServer:ClientId"),
                   _config.GetValue<string>("SpotifyServer:SecretId"),
                   response.Code, new Uri("http://localhost:5000/callback"))
            );
            using (FileStream fs = new FileStream(@"..\..\..\..\Spefy.Core\Files\Token.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(token.AccessToken);
                    sw.WriteLine(token.TokenType);
                    sw.WriteLine(token.RefreshToken);
                    sw.WriteLine(token.ExpiresIn);
                    sw.WriteLine(token.CreatedAt);
                }
                
            }

            var ClientContent = SpotifyClientConfig.CreateDefault().WithToken(token.AccessToken, token.TokenType);
            var client = new SpotifyClient(ClientContent);
        }

    }
}
