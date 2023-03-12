using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ExternalLibrary
{
    public static class Tracing
    {
        public static void Trace(string message,
            [CallerFilePath] string fileName = "unknown file",
            [CallerMemberName] string methodName = "unknown method",
            [CallerLineNumber] int lineNumber = 0)
        {
            System.Diagnostics.Trace.WriteLine($"Message from {methodName} (in file {Path.GetFileName(fileName)}) at line {lineNumber} :{Environment.NewLine}{message}");
        }
    }

}
