using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web.Auth;


namespace Spefy.Core.SpotifyProvider.SpotifyServer
{
    internal class SpotifyServerProvider : EmbedIOAuthServer, ISpotifyServerProvider
    {
        public SpotifyServerProvider(IConfiguration config) : base(GetUri(config), GetPort(config))
        {

        }
        public static Uri GetUri(IConfiguration config)
        {
            return new Uri(config.GetValue<string>("SpotifyServer:Url") ?? "http://localhost:5000/callback");
        }
        public static int GetPort(IConfiguration config)
        {
            return config.GetValue<int>("SpotifyServer:Port");
        }
    }
}
