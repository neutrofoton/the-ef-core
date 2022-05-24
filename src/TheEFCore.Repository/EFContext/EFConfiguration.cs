using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TheEFCore.Repository.EFContext
{
    public class EFConfiguration
    {
        public static void Configure(HostBuilderContext host, IServiceCollection services)
        {
            services
                .AddDbContext<EFDbContext>(options =>
                {
                    //options.UseNpgsql(
                    //    host.Configuration.GetConnectionString("TheEFCore"),
                    //    builder => builder.MigrationsAssembly("TheEFCore.Migration"));

                    options.UseNpgsql(
                       host.Configuration.GetConnectionString("TheEFCore"));

                }, ServiceLifetime.Singleton);
        }
    }
}
