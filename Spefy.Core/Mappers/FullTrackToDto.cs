using Spefy.Contract.Dtos.Track;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Mappers
{
    public static class FullTrackToDto
    {
        public static TrackDataDto ToDto(this FullTrack track)
        {
            var trackDto = new TrackDataDto()
            {
                ArtistName = track.Artists.First().Name,
                Album = track.Album.ToSimpleDto(),
                Id = track.Id,
                Duration = track.DurationMs,
                Popularity = track.Popularity,
                TrackNumber = track.TrackNumber,
                Explicit = track.Explicit,
                Title = track.Name

            };
            return trackDto;
        }
    }
}
