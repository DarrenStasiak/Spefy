using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Threading.Tasks;

namespace SpefyClassLibrary
{
    public class SpotifyService
    {
        public static SpotifyClientConfig ClientContent;
        public static SpotifyClient Client;
        public static EmbedIOAuthServer _server;

        public SpotifyService()
        {



        }


        public async void Init()
        {

            _server = new EmbedIOAuthServer(new Uri("http://localhost:5000/callback"), 5000);
            await _server.Start();

            _server.AuthorizationCodeReceived += OnAuthorizationCodeReceived;

            var request = new LoginRequest(_server.BaseUri, "e5c6cdfe23c2458685ca6cc51fffe7f7", LoginRequest.ResponseType.Code)
            {
                Scope = new List<string> { Scopes.UserReadEmail }
            };

            Uri uri = request.ToUri();

            try
            {
                BrowserUtil.Open(uri);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to open URL, manually open: {0}", uri);
            }
            Console.ReadLine();



        }

        public async Task GetName(string id)
        {
            var spotify = new SpotifyClient(ClientContent);
            var track = Client.Tracks.Get(id);
            Console.WriteLine(track.Result.Name);

        }

        private async Task OnAuthorizationCodeReceived(object sender, AuthorizationCodeResponse response)
        {
            await _server.Stop();
            var config = SpotifyClientConfig.CreateDefault();
            AuthorizationCodeTokenResponse token = await new OAuthClient(config).RequestToken(
              new AuthorizationCodeTokenRequest(
                   "e5c6cdfe23c2458685ca6cc51fffe7f7",
                   "d26f03b4c45c451b8637d32d9a96eda0",
                   response.Code, new Uri("http://localhost:5000/callback"))
            );

            ClientContent = SpotifyClientConfig.CreateDefault().WithToken(token.AccessToken, token.TokenType);
            var spotify = new SpotifyClient(ClientContent);
            Console.Clear();

            var track = await spotify.Tracks.Get("11dFghVXANMlKmJXsNCbNl");
            Console.WriteLine(track.Name);
            Client = spotify;
        }
    }
}
