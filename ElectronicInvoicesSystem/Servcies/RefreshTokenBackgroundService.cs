using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Servcies
{
    public class RefreshTokenBackgroundService : BackgroundService
    {
        private readonly IWorker worker;

        public RefreshTokenBackgroundService(IWorker worker)
        {
            this.worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await worker.DoWork(stoppingToken);
        }
    }
}
