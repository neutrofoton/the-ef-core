using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TheEFCore.Repository.EFContext;

namespace TheEFCore.PresentationApp
{
    internal class Startup : BackgroundService
    {
        private readonly EFDbContext context;

        public Startup(EFDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
