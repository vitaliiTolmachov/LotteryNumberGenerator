using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace LotteryNumberGenerator
{
    public interface IGeneratorConfigurationBuilder
    {
        IGeneratorConfiguration Build();
    }

    public class GeneratorConfigurationBuilder : IGeneratorConfigurationBuilder
    {
        private readonly IConfiguration _configuration;
        private const string CONFIGURATIONKEY = "GeneratorConfiguration";

        public GeneratorConfigurationBuilder(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IGeneratorConfiguration Build()
        {
            var section = _configuration.GetSection(CONFIGURATIONKEY);

            //TODO: Read from Configuration

            return new GeneratorConfiguration
            {
                CombinationLength = 6,
                MinValidValue = 0,
                MaxValidValue = 50
            };
        }
    }
}
