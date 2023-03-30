using Spefy.Contract.Dtos.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Contract.Dtos.Track
{
    public class TrackDataDto
    {
        public string Id { get; set; }
        public SimpleAlbumDto Album { get; set; }
        public string ArtistName { get; set; }
        public int Duration { get; set; }
        public string Title { get; set; }
        public int Popularity { get; set; }
        public int TrackNumber { get; set; }
        public bool Explicit { get; set; }

        
    }
}
