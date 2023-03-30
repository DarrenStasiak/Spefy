using Spefy.Contract.Dtos.Artist;
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

namespace Spefy.Core.Services.Artists
{
    internal class ArtistService : IArtistService
    {
        private readonly IAuthorizeService _authorizeService;
        public ArtistService(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }
        public async Task<ArtistDataDto> GetArtistById(string Id)
        {
            string token = _authorizeService.GetToken();
            string tokenType = _authorizeService.GetTokenType();
            if (!string.IsNullOrEmpty(token))
            {
                var clientContent = SpotifyClientConfig.CreateDefault().WithToken(token, tokenType);
                var client = new SpotifyClient(clientContent);
                var artistData = await client.Artists.Get(Id);

                return artistData.ToDto();
            }
            else
            {
                throw new ValidTokenException();
            }
            return new ArtistDataDto();
        }
        public async Task<List<string>> SearchForArtists(string query)
        {
            string token = _authorizeService.GetToken();
            string tokenType = _authorizeService.GetTokenType();
            if (!string.IsNullOrEmpty(token))
            {
                var clientContent = SpotifyClientConfig.CreateDefault().WithToken(token, tokenType);
                var client = new SpotifyClient(clientContent);
                var artistData = await client.Search.Item(
                new SearchRequest(SearchRequest.Types.Artist, query)
                {
                    Limit = 10
                });
                var data = artistData.Artists.Items
                    .Select(x => "Name: " + x.Name + " Popularity: " + x.Popularity + " Followers Count: " + x.Followers.Total + " Generes: " + stringifyList(x.Genres)).ToList();
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
