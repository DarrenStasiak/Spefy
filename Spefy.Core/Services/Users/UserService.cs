using Spefy.Contract.Dtos.User;
using Spefy.Core.Exceptions.User;
using Spefy.Core.Mappers;
using Spefy.Core.Services.Auth;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.Services.Users
{
    internal class UserService : IUserService
    {
        private readonly IAuthorizeService _authorizeService;

        public UserService(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        public async Task<UserDataDto> GetUserDataAsync()
        {
            string token = _authorizeService.GetToken();
            string tokenType = _authorizeService.GetTokenType();
            if(!string.IsNullOrEmpty(token) ) 
            {
                var clientContent = SpotifyClientConfig.CreateDefault().WithToken(token, tokenType);
                var client = new SpotifyClient(clientContent);
                var userData = await client.UserProfile.Current();
                var userDto = userData.ToDto();
                return userDto;
            }
            else
            {
                throw new ValidTokenException();
            }

            return new UserDataDto();
        }
    }
}
