using System;
using Microsoft.Extensions.Logging;

namespace LotteryNumberGenerator
{
    public interface IResultPresenter
    {
        void ShowResult(ILotteryResult result);
    }

    public class DefaultResultPresenter : IResultPresenter
    {
        private readonly ILogger _logger;

        public DefaultResultPresenter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory?.CreateLogger<DefaultResultPresenter>() ??
                      throw new ArgumentNullException(nameof(loggerFactory));
        }

        public void ShowResult(ILotteryResult result)
        {
            Console.WriteLine("Win combination is: {0}", string.Join(',', result.Result));
        }
    }
}