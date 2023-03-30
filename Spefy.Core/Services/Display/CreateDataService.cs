using Spefy.Core.Services.Playlists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Display
{
    internal class CreateDataService : ICreateDataService
    {
        private readonly IPlaylistService _playlistService;
        public CreateDataService(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        public void CreatePlaylistMenu()
        {
            throw new NotImplementedException();
        }

        public void DeletePlaylistMenu()
        {
            throw new NotImplementedException();
        }
    }
}
