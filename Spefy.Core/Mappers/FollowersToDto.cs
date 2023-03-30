using Spefy.Contract.Dtos.ValueObjects;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Mappers
{
    public static class FollowersToDto
    {
        public static FollowersDto ToDto(this Followers followers)
        {
            var follower = new FollowersDto()
            {
                href = followers?.Href,
                total = followers?.Total,
            };
            return follower;
        }
    }
}
