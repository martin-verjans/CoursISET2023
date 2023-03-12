using ExternalLibrary;
using System;
using System.Diagnostics;

namespace GetCallerInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            Console.WriteLine("Starting program");

            Tracing.Trace("Starting up");

            AnotherClass c = new AnotherClass();
            c.DoSomeStuff();

            Tracing.Trace("All operation completed");

            Console.ReadKey();
            Console.WriteLine("End of program, press a key to exit");
        }
    }
}
