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
            throw new NotImplementedException();
        }

        public async Task DisplaySongDataMenu()
        {
            throw new NotImplementedException();
        }

        public async Task DisplayUserDataMenu()
        {
            Console.Clear();
            var user = await _userService.GetUserDataAsync();
            Console.WriteLine(user.Humanize());
        }
    }
}
