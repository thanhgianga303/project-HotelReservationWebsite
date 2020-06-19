using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace BookingAPI
{
    public class BusService : BackgroundService
    {
        private readonly IBusControl _busControl;

        public BusService(IBusControl busControl)
        {
            _busControl = busControl;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("BusService started");
            return _busControl.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("BusService stopped");
            return _busControl.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
