using System;
using System.Collections.Generic;

namespace LotteryNumberGenerator
{
    public interface IRandomGenerator
    {
        ILotteryResult Generate();
    }

    public class DefaultSequenceGenerator : IRandomGenerator
    {
        private readonly Random _random = new Random();

        private readonly IGeneratorConfiguration _generatorConfiguration;

        public DefaultSequenceGenerator(IGeneratorConfiguration generatorConfiguration)
        {
            _generatorConfiguration =
                generatorConfiguration ?? throw new ArgumentNullException(nameof(generatorConfiguration));
        }

        public ILotteryResult Generate()
        {
            var result = new List<int>(_generatorConfiguration.CombinationLength);

            for (int i = 0; i < _generatorConfiguration.CombinationLength; i++)
            {
                var number = GetRandomNumber();

                while (result.Contains(number))
                {
                    number = GetRandomNumber();
                }
                result.Add(number);

            }

            return LotteryResult.Create(result.ToArray());

            int GetRandomNumber()
            {
                var number = _random.Next(_generatorConfiguration.MinValidValue, _generatorConfiguration.MaxValidValue);
                return number;
            }
        }
    }
}