namespace Spefy.Core.Services.Display
{
    public interface IDisplayDataService
    {
         Task DisplayUserDataMenu();
         Task DisplayArtistDataMenu();
         Task DisplaySongDataMenu();
    }
}