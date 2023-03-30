using Microsoft.Extensions.DependencyInjection;
using Spefy.Core.Services.Users;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using Spefy.Core.Services.Albums;
using Spefy.Core.Services.Artists;
using Spefy.Core.Services.Tracks;
using Spefy.Core.Services.Playlists;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web;
using Spefy.Core.SpotifyProvider.SpotifyServer;
using Spefy.Core.Services.Auth;

namespace Spefy.Core.Services
{
    public static class Extensions
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IAuthorizeService, AuthorizeService>();

            services.AddScoped<ISpotifyClient, SpotifyClient>();


            return services;
        }
    }
}
