using Microsoft.Extensions.DependencyInjection;
using Spefy.Core.Services.Albums;
using Spefy.Core.Services.Artists;
using Spefy.Core.Services.Playlists;
using Spefy.Core.Services.Tracks;
using Spefy.Core.Services.Users;
using Spefy.Core.SpotifyProvider.SpotifyServer;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core.SpotifyProvider
{
    public static class Extensions
    {
        internal static IServiceCollection AddInfrastracture(this IServiceCollection services)
        {
            services.AddScoped<ISpotifyServerProvider, SpotifyServerProvider>();

            return services;
        }
    }
}
