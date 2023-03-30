using Spefy.Contract.Dtos.Album;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Mappers
{
    public static class SimpleAlbumToSimpleDto
    {
        public static SimpleAlbumDto ToSimpleDto(this SimpleAlbum album)
        {
            var albumDto = new SimpleAlbumDto()
            {
                Id = album.Id,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
                Type = album.Type,
                Url = album.ExternalUrls["spotify"]
            };
            return albumDto;
        }
    }
}
