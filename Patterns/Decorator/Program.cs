using Decorator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


var applicationBuilder = Host.CreateApplicationBuilder();

var services = applicationBuilder.Services;

services.AddHostedService<StartupService>();

services.BuildServiceProvider();

applicationBuilder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.ColorBehavior = LoggerColorBehavior.Disabled;
});
    


var host = applicationBuilder.Build();

host.Run();
