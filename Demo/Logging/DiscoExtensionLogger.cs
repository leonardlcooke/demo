using Dapper;
using DirectScale.Disco.Extension.Services;
using System;

namespace Demo.Logging
{
    public class DiscoExtensionLogger : IDiscoExtensionLogger
    {
        private readonly IDataService _dataService;

        public DiscoExtensionLogger(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void LogCritical(string msg)
        {
            LogMessage(msg, LogLevel.Critical);
        }

        public void LogDebug(string msg)
        {
            LogMessage(msg, LogLevel.Debug);
        }

        public void LogError(string msg)
        {
            LogMessage(msg, LogLevel.Error);
        }

        public void LogInfo(string msg)
        {
            LogMessage(msg, LogLevel.Info);
        }

        private void LogMessage(string msg, LogLevel level) 
        {
            var logMessage = new DiscoExtensionLogMessage(DateTime.Now, msg, level);

            try
            {
                using (var dbConnection = new System.Data.SqlClient.SqlConnection(_dataService.ClientConnectionString.ConnectionString))
                {
                    string sql = "INSERT INTO Client.logs([datetime], [message], [lvl]) VALUES (@DateTimeStamp, @Message, @LevelString); SELECT CAST (SCOPE_IDENTITY() as int)";
                    int result = dbConnection.Execute(sql, logMessage);
                }
            }
            catch { }          
        }

        public enum LogLevel
        {
            Debug = 1,
            Info = 2,
            Error = 3,
            Critical = 4
        }


    }
}
