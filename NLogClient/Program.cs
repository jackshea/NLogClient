using NLog;
using System;
using System.Threading;

namespace NLogClient
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.Configuration.Variables["UserId"] = "xzk" + new Random((int)DateTime.Now.Ticks).Next(100);
            var logger = LogManager.GetCurrentClassLogger();
            logger.Info("Test Nlog level.");
            logger.Trace("Trace" );
            logger.Debug("Debug" );
            logger.Info("Info");
            logger.Warn("Warn" );
            logger.Error("Error");
            logger.Fatal("Fatal");

            for (int i = 0; i < 100; i++)
            {
                logger.Info( i);
                Thread.Sleep(1000);
            }

            LogManager.Flush((a) =>
            {
                LogManager.Shutdown();
            }, TimeSpan.FromSeconds(2));

        }
    }
}
