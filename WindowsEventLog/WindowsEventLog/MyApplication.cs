using System;
using System.Threading;

namespace WindowsEventLog
{
    internal class MyApplication
    {
        private readonly Logger logger;
        public MyApplication(Logger logger)
        {
            this.logger = logger;
        }

        public void PerformSomeWork()
        {
            logger.Log("Starting Work");
            for (int i = 0; i < 1000; i++)
            {
                logger.Log($"Performing action {i}");
                Console.WriteLine($"Performing action {i}");
            }
            logger.Log("An error has occured", LogLevel.Error);
            logger.Log("A warning has occured", LogLevel.Warning);
            logger.Log("Job is finished");
            throw new System.Exception("An great error has occured");
        }
    }
}
