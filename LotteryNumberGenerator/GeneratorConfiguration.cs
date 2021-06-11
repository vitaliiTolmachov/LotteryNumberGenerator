using System;
using System.Collections.Generic;
using System.Text;

namespace LotteryNumberGenerator
{
    public interface IGeneratorConfiguration
    {
        int CombinationLength { get; set; }

        int MinValidValue { get; set; }

        int MaxValidValue { get; set; }
    }

    public class GeneratorConfiguration : IGeneratorConfiguration
    {
        //TODO: Add static Crate method with getters only

        public int CombinationLength { get; set; }

        //Add NonPositive guard on object initialization
        public int MinValidValue { get; set; }

        public int MaxValidValue { get; set; }
    }
}
