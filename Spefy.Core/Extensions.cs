using Microsoft.Extensions.DependencyInjection;
using Spefy.Core.Services;
using Spefy.Core.SpotifyProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spefy.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddServices();
            services.AddInfrastracture();

            return services;
        }
    }
}
