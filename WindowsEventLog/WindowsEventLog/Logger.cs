using System;
using System.Diagnostics;
using System.Security;

namespace WindowsEventLog
{
    internal class Logger : IDisposable
    {
        private const string EVENTSOURCE = "ISET2023";
        private const string LOGNAME = "MyCustomLogForISET";
        private readonly EventLog log;

        public Logger()
        {
            CreateSourceIfNotExist();
            log = new EventLog(LOGNAME)
            {
                Source = EVENTSOURCE
            };
        }
        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            log.WriteEntry(message, (EventLogEntryType)level);
        }

        private void CreateSourceIfNotExist()
        {
            try
            {
                if (!EventLog.SourceExists(EVENTSOURCE))
                {
                    CreateSource();
                }
            }
            catch (SecurityException)
            {
                //We don't have the rights
            }
        }


        private static void CreateSource()
        {
            EventLog.CreateEventSource(EVENTSOURCE, LOGNAME);
        }

        public void Dispose()
        {
            ((IDisposable)log).Dispose();
        }
    }
}
