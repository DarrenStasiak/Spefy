using Spefy.Contract.Dtos.Artist;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Mappers
{
    public static class FullArtistToDto
    {
        public static ArtistDataDto ToDto(this FullArtist artist)
        {
            var artistDto = new ArtistDataDto()
            {
                Id = artist.Id,
                Name = artist.Name,
                Popularity = artist.Popularity,
                Generes = artist.Genres,
                followers = artist.Followers.ToDto()
            };
            return artistDto;
        }
    }
}
