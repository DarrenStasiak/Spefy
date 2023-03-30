using SpefyClassLibrary.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using Swan;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpefyClassLibrary.Services
{
    public class SpotifyService
    {
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
                Scope = new List<string> { 
                    Scopes.UserReadEmail, 
                    Scopes.PlaylistModifyPrivate,
                    Scopes.PlaylistModifyPublic,
                    Scopes.PlaylistReadPrivate,
                    Scopes.UserReadRecentlyPlayed,
                    Scopes.UserTopRead
                }
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

        public async Task PopulateDatasetPlaylist(string id)
        {
            var playlist = Client.Playlists.GetItems(id);
            List<string> TracksIds= new List<string>();
            foreach (var track in playlist.Result.Items) 
            {
                if(track.Track != null) 
                TracksIds.Add(track.Track.ReadProperty("Id").ToString());
            }
            using (var context = new TrackDatasetContext())
            {
                foreach (string trackId in TracksIds)
                {
                var track = Client.Tracks.Get(trackId).Result;
                var trackAnal = Client.Tracks.GetAudioFeatures(trackId).Result;
                string artist = track.Artists.First().Id;
                string generes = String.Join("|", Client.Artists.Get(artist).Result.Genres);


                Track newTrack = new Track { 
                    Id= trackId,
                    Name = track.Name,
                    Acousticness = trackAnal.Acousticness,
                    Danceability= trackAnal.Danceability,
                    Energy= trackAnal.Energy,
                    Instrumentalness= trackAnal.Instrumentalness,
                    Key = trackAnal.Key,
                    Liveness= trackAnal.Liveness,
                    Mode= trackAnal.Mode,
                    Speechiness= trackAnal.Speechiness,
                    Tempo= trackAnal.Tempo,
                    Time_signature= trackAnal.TimeSignature,
                    Valence= trackAnal.Valence,
                    Popularity = track.Popularity,
                    Generes= generes,
                };
                
                    context.Add(newTrack);
                    

                    Console.WriteLine(newTrack.Humanize());
                }
                context.SaveChanges();
            }
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

            var ClientContent = SpotifyClientConfig.CreateDefault().WithToken(token.AccessToken, token.TokenType);
            Client = new SpotifyClient(ClientContent);
            Console.Clear();

        }
    }
}
