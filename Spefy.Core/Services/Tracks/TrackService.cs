using Spefy.Contract.Dtos.Track;
using Spefy.Core.Exceptions.User;
using Spefy.Core.Mappers;
using Spefy.Core.Services.Auth;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Tracks
{
    internal class TrackService : ITrackService
    {
        private readonly IAuthorizeService _authorizeService;
        public TrackService(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        public async Task<TrackDataDto> GetTrackById(string id)
        {
            string token = _authorizeService.GetToken();
            string tokenType = _authorizeService.GetTokenType();
            if (!string.IsNullOrEmpty(token))
            {
                var clientContent = SpotifyClientConfig.CreateDefault().WithToken(token, tokenType);
                var client = new SpotifyClient(clientContent);
                var trackData = await client.Tracks.Get(id); 

                return trackData.ToDto();
            }
            else
            {
                throw new ValidTokenException();
            }
            return new TrackDataDto();
        }
        public async Task<List<string>> SearchForTracks(string query)
        {
            string token = _authorizeService.GetToken();
            string tokenType = _authorizeService.GetTokenType();
            if (!string.IsNullOrEmpty(token))
            {
                var clientContent = SpotifyClientConfig.CreateDefault().WithToken(token, tokenType);
                var client = new SpotifyClient(clientContent);
                var artistData = await client.Search.Item(
                new SearchRequest(SearchRequest.Types.Track, query)
                {
                    Limit = 10
                });
                var data = artistData.Tracks.Items
                    .Select(x => "Name: " + x.Name + 
                                 " Popularity: " + x.Popularity + 
                                 " Album: " + x.Album + 
                                 " Artists: " + 
                                 stringifyList(x.Artists.Select(x => x.Name).ToList())).ToList();
                return data;
            }
            else
            {
                throw new ValidTokenException();
            }
            return new List<string>();
        }
        private string stringifyList(List<string> list)
        {
            var result = "";
            foreach (var item in list)
            {
                result += (item + ", ");
            }
            return result;
        }
    }
}
