using System;
using System.Threading;

namespace SauceDemoTests.Core
{
    public static class RetryHelper
    {
        public static void Retry(Action action, int attempts = 3)
        {
            for (int i = 1; i <= attempts; i++)
            {
                try
                {
                    action();
                    return;
                }
                catch when (i < attempts)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}