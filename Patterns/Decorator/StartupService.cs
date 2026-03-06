using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Decorator
{
    internal class StartupService (IServiceProvider serviceProvider, ILogger<StartupService> logger, IHostApplicationLifetime applicationLifetime) : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new CustomerReceiptSettings(new List<string>() { "CustomerDrink", "CustomerDiscountCode" });
            var customerReceipt = CustomerReceiptFactory.GetCustomerReceipt(config, serviceProvider);

            var amount = customerReceipt?.CalculateAmount() ?? -1;

            logger.LogInformation("Calculated amount: {Amount}", amount);


            // all done
            applicationLifetime.StopApplication();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
