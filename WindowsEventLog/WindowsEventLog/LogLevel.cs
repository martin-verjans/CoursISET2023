using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEventLog
{
    internal enum LogLevel
    {
        Info = EventLogEntryType.Information,
        Warning = EventLogEntryType.Warning,
        Error = EventLogEntryType.Error
    }
}
