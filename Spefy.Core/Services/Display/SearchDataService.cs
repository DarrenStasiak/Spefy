using Spefy.Core.Services.Artists;
using Spefy.Core.Services.Tracks;
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
        public void SearchArtistMenu()
        {
            

        }

        public void SearchTrackMenu()
        {


        }
    }
}
