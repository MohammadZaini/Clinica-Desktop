using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_DataAccess
{
    internal class clsDataAccessSettings
    {
        public static string connectionString = "Server = .; Database = ClinicDB; User ID = sa; Password = sa123456";

        public static void LogEvent(string logMessage)
        {
            string sourceName = "Clinica";

            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            EventLog.WriteEntry(sourceName, logMessage, EventLogEntryType.Error);
        }
    }
}
