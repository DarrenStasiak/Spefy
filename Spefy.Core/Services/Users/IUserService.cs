using Spefy.Contract.Dtos.User;

namespace Spefy.Core.Services.Users
{
    public interface IUserService
    {
        public Task<UserDataDto> GetUserDataAsync();
        public Task<string> GetUserId();
    }
}