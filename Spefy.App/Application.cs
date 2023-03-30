using Spefy.Core.Services.Auth;
using Spefy.Core.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.App
{
    public class Application : IApplication
    {
        private readonly IAuthorizeService _authorizeService;
        private readonly IUserService _userService;

        public Application(IAuthorizeService authorizeService, IUserService userService)
        {
            _authorizeService = authorizeService;
            _userService = userService;
        }

        public void Run()
        {
            _authorizeService.Authorize();

            while ()
            {

            }
            var user = Task.Run(() => _userService.GetUserDataAsync()).Result;

        }
        private int StartMenu()
        {
            Console.WriteLine("____SPEFY____ \n\n");
            Console.WriteLine("Choose Option");
            Console.WriteLine("1.Display Data");
            Console.WriteLine("2.Create Playlist");
            Console.WriteLine("3.Search");

            string x = Console.ReadLine();

            if (int.TryParse(x, out int result))
            {
                if(result > 0 &&  result < 4) 
                { 
                
                }
            }

            return 0;
        }
    }
}
