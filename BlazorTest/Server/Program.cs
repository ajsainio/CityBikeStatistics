using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace BlazorTest.Server {
  public class Program {
    public static void Main(string[] args) {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) {
      var host = Host.CreateDefaultBuilder(args);
      host.ConfigureWebHostDefaults(webBuilder => {
        webBuilder.UseStartup<Startup>();
      });
      host.UseNServiceBus(context => {
        var endpointConfig = new EndpointConfiguration("CityBikeData");
        endpointConfig.PurgeOnStartup(true);
        endpointConfig.UseTransport<LearningTransport>().NoPayloadSizeRestriction();
        var recoverability = endpointConfig.Recoverability();
        recoverability.Immediate(r => r.NumberOfRetries(1));
        recoverability.Delayed(r => r.NumberOfRetries(0));
        return endpointConfig;
      });
      return host;
    }
  }
}
