using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LotteryNumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var appConfig = GetConfiguration();
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(appConfig)
                .AddLogging()
                .AddSingleton<IGeneratorConfigurationBuilder, GeneratorConfigurationBuilder>()
                .AddSingleton<IRandomGenerator, DefaultSequenceGenerator>(sp =>
                {
                    var generationBuilder = sp.GetRequiredService<IGeneratorConfigurationBuilder>();
                    return new DefaultSequenceGenerator(generationBuilder.Build());
                })
                .AddSingleton<IResultPresenter, DefaultResultPresenter>()
                .BuildServiceProvider();

            RunLottery(serviceProvider);

        }

        private static void RunLottery(IServiceProvider serviceProvider)
        {
            var resultGenerator = serviceProvider.GetRequiredService<IRandomGenerator>();
            var lotteryResult = resultGenerator.Generate();

            var resultPresenter = serviceProvider.GetRequiredService<IResultPresenter>();
            resultPresenter.ShowResult(lotteryResult);
        }

        private static IConfiguration GetConfiguration()
        {
            var appConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("appSettings.json", false, reloadOnChange:true)
                .Build();

            return appConfig;
        }
    }
}
