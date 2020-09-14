using ExpressEntryCalculator.Api.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ExpressEntryCalculator.Api.Startup))]

namespace ExpressEntryCalculator.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ISystemTime>((s) => {
                return new SystemTime();
            });
        }
    }
}