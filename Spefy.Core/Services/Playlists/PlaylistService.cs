using Spefy.Core.Services.Auth;
using Spefy.Core.Services.Users;
using SpotifyAPI.Web;
using Swan.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Playlists
{
    internal class PlaylistService : IPlaylistService
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IUserService _userService;
        public PlaylistService(IAuthorizeService authorizeService, IUserService userService)
        {
            _authorizeService = authorizeService;
            _userService = userService;
        }

        public async Task CreatePlaylist(string name, bool isPublic, string description)
        {
            var ClientContent = SpotifyClientConfig.CreateDefault().WithToken(_authorizeService.GetToken(), _authorizeService.GetTokenType());
            var client = new SpotifyClient(ClientContent);
            await client.Playlists.Create(await _userService.GetUserId(), new PlaylistCreateRequest(name)
            {
                Description = description,
                Public = isPublic
            });
        }

    }
}
