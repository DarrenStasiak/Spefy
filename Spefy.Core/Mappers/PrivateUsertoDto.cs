using Spefy.Contract.Dtos.User;
using Spefy.Contract.Dtos.User.ValueObjects;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Mappers
{
    public static class PrivateUsertoDto
    {
        public static UserDataDto ToDto(this PrivateUser user)
        {
            UserDataDto dto = new UserDataDto()
            {
                BasicUserData = new BasicUserDataDto()
                {
                    Id = user.Id,
                    Country = user?.Country,
                    Email = user?.Email,
                },
                Uri = user?.Uri,
                Name = user?.DisplayName,
                ExternalUrls = user?.ExternalUrls,
                Type = user?.Type,
                Product = user?.Product,
                Href = user?.Href,
                followers = new FollowersDto()
                {
                    total = user.Followers?.Total,
                    href = user.Followers?.Href,
                }
            };
            return dto;
        }
    }
}
