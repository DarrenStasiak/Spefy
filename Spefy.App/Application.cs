using Spefy.Core.Services.Auth;
using Spefy.Core.Services.Display;
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
        private readonly IDisplayDataService _displayDataService;
        private readonly ICreateDataService _createDataService;
        private readonly ISearchDataService _searchDataService;


        public Application(IAuthorizeService authorizeService,
                           IDisplayDataService displayDataService,
                           ICreateDataService createDataService,
                           ISearchDataService searchDataService)
        {
            _authorizeService = authorizeService;
            _displayDataService = displayDataService;
            _createDataService = createDataService; 
            _searchDataService = searchDataService;
        }

        public void Run()
        {
            _authorizeService.Authorize();

            var option = StartMenu();
            switch (option)
            {
                case 1:
                    DisplayMenu();
                    break;

                case 2:
                    CreateMenu();
                    break;

                case 3:
                    SearchMenu();
                    break;
            }

        }
        private int StartMenu()
        {
            Console.WriteLine("____SPEFY____ \n\n");
            Console.WriteLine("Choose Option");
            Console.WriteLine("1.Display Data");
            Console.WriteLine("2.Create Playlist");
            Console.WriteLine("3.Search");



            while (true)
            {
                string x = Console.ReadLine();
                if (int.TryParse(x, out int result))
                {
                    if (result > 0 && result < 4)
                    {
                        Console.Clear();
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("no option of given number ");
                    }
                }
                else
                {
                    Console.WriteLine("Please Pass int value");
                }
            }
            Console.Clear();
            return 0;
        }
        private void DisplayMenu()
        {
            Console.WriteLine("____SPEFY____ \n\n");
            Console.WriteLine("Choose Option");
            Console.WriteLine("1.Current User Data");
            Console.WriteLine("2.Artist Data");
            Console.WriteLine("3.Song Data");



            while (true)
            {
                string x = Console.ReadLine();
                if (int.TryParse(x, out int result))
                {
                    if (result > 0 && result < 4)
                    {
                        Console.Clear();
                        switch (result)
                        {
                            case 1:
                                _displayDataService.DisplayUserDataMenu();
                                break;

                            case 2:
                                _displayDataService.DisplayArtistDataMenu();
                                break;

                            case 3:
                                _displayDataService.DisplaySongDataMenu();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("no option of given number ");
                    }
                }
                else
                {
                    Console.WriteLine("Please Pass int value");
                }
            }
        }
        private void CreateMenu()
        {
            Console.WriteLine("____SPEFY____ \n\n");
            Console.WriteLine("Choose Option");
            Console.WriteLine("1.Create Playlist");
            Console.WriteLine("2.Delete Playlist");



            while (true)
            {
                string x = Console.ReadLine();
                if (int.TryParse(x, out int result))
                {
                    if (result > 0 && result < 3)
                    {
                        Console.Clear();
                        switch (result)
                        {
                            case 1:
                                _createDataService.CreatePlaylistMenu();
                                break;

                            case 2:
                                _createDataService.DeletePlaylistMenu();
                                break;


                        }
                    }
                    else
                    {
                        Console.WriteLine("no option of given number ");
                    }
                }
                else
                {
                    Console.WriteLine("Please Pass int value");
                }
            }

        }
        private void SearchMenu()
        {
            Console.WriteLine("____SPEFY____ \n\n");
            Console.WriteLine("Choose Option");
            Console.WriteLine("1.Search Track");
            Console.WriteLine("2.Search User/Artist");

            while (true)
            {
                string x = Console.ReadLine();
                if (int.TryParse(x, out int result))
                {
                    if (result > 0 && result < 3)
                    {
                        Console.Clear();
                        switch (result)
                        {
                            case 1:
                                _searchDataService.SearchTrackMenu();
                                break;

                            case 2:
                                _searchDataService.SearchArtistMenu();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("no option of given number ");
                    }
                }
                else
                {
                    Console.WriteLine("Please Pass int value");
                }
            }
        }
    }
}
