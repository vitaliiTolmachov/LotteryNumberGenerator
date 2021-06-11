using System;
using System.Collections.Generic;
using System.Text;

namespace LotteryNumberGenerator
{
    public interface ILotteryResult
    {
        int[] Result { get; }
    }

    public class LotteryResult : ILotteryResult
    {
        public static ILotteryResult Create(int[] resultSequence)
        {
            if(resultSequence == null)
                throw new ArgumentNullException(nameof(resultSequence));

            return new LotteryResult() {Result = resultSequence };
        }

        public int[] Result { get; private set; }
    }
}
