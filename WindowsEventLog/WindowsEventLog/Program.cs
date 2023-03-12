using System;

namespace WindowsEventLog
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            using (Logger logger = new Logger())
            {
                logger.Log("From Main, starting application");
                RunApplication(logger);
                logger.Log("From Main, ending application");
            }
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }

        private static void RunApplication(Logger logger)
        {
            MyApplication app = new MyApplication(logger);
            try
            {
                app.PerformSomeWork();
            }
            catch (Exception ex)
            {
                logger.Log($"Error occured in application : {ex.Message}{Environment.NewLine}{ex.StackTrace}", LogLevel.Error);
            }
        }
    }
}
