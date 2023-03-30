using Spefy.Core.Services.Artists;
using Spefy.Core.Services.Tracks;
using Swan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Display
{
    internal class SearchDataService : ISearchDataService
    {
        private readonly ITrackService _trackService;
        private readonly IArtistService _artistService;
        public SearchDataService(ITrackService trackService, IArtistService artistService) 
        { 
            _trackService = trackService;
            _artistService = artistService;
        }
        public async void SearchArtistMenu()
        {

            Console.Clear();
            Console.WriteLine("Insert search query");
            var query = Console.ReadLine();
            var artists = await _artistService.SearchForArtists(query);
            if (artists != null && artists.Count > 0)
            {
                foreach (var artistItem in artists)
                {
                    Console.WriteLine(artistItem);
                }
            }
            else
            {
                Console.WriteLine("Artist not found");
            }
            Console.ReadLine();
        }

        public async void SearchTrackMenu()
        {
            Console.Clear();
            Console.WriteLine("Insert search query");
            var query = Console.ReadLine();
            var tracks = await _trackService.SearchForTracks(query);
            if (tracks != null && tracks.Count > 0)
            {
                foreach (var track in tracks)
                {
                    Console.WriteLine(track);
                }
            }
            else
            {
                Console.WriteLine("Track not found");
            }
            Console.ReadLine();

        }
    }
}
