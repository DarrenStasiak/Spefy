using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Playlists
{
    public interface IPlaylistService
    {
        public Task CreatePlaylist(string name, bool isPublic, string description);
    }
}
