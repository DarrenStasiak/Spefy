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

        public async void CreatePlaylistMenu()
        {
            Console.Clear();
            Console.WriteLine("Give playlist name");
            var name = Console.ReadLine();
            Console.WriteLine("Give playlist description");
            var description = Console.ReadLine();
            Console.WriteLine("is it public (y/n)");
            var isPulic = true;
            while (true)
            {
                var result = Console.ReadLine();
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                if (result.Equals("y") || result.Equals("n"))
                {
                    if (result.Equals("n")) isPulic = false;
                    else isPulic = true;
                    break;
                }
            }


            await _playlistService.CreatePlaylist(name, isPulic, description);
            Console.WriteLine("playlist created");
            Console.ReadLine();
        }

    }
}
