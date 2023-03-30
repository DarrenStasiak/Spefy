using Spefy.Core.Services.Artists;
using Spefy.Core.Services.Tracks;
using Spefy.Core.Services.Users;
using Swan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Display
{
    internal class DisplayDataService : IDisplayDataService
    {
        private readonly IUserService _userService;
        private readonly IArtistService _artistService;
        private readonly ITrackService _trackService;
        public DisplayDataService(IUserService userService, IArtistService artistService, ITrackService trackService)
        {
            _userService = userService;
            _artistService = artistService;
            _trackService = trackService;
        }

        public async Task DisplayArtistDataMenu()
        {
            Console.Clear();
            Console.WriteLine("Insert Song Id");
            var id = Console.ReadLine();
            var artist = await _artistService.GetArtistById(id);
            if (artist != null)
            {
                Console.WriteLine(artist.ToJson());
            }
            else
            {
                Console.WriteLine("Artist not found");
            }
            Console.ReadLine();
        }

        public async Task DisplaySongDataMenu()
        {
            Console.Clear();
            Console.WriteLine("Insert Song Id");
            var id = Console.ReadLine();
            var song = await _trackService.GetTrackById(id);
            if(song != null)
            {
                Console.WriteLine(song.ToJson());
            }
            else
            {
                Console.WriteLine("Song not found");
            }
            Console.ReadLine();

        }

        public async Task DisplayUserDataMenu()
        {
            Console.Clear();
            var user = await _userService.GetUserDataAsync();
            Console.WriteLine(user.ToJson());
            Console.ReadLine();
        }
    }
}
