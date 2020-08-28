using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Logging
{
    public class DiscoExtensionLogMessage
    {
        public DiscoExtensionLogMessage(DateTime timeStamp, string msg, DiscoExtensionLogger.LogLevel level)
        {
            this.DateTimeStamp = timeStamp;
            this.Message = msg;
            this.Level = level;
        }

        public DateTime DateTimeStamp { get; set; }
        public string Message { get; set; }
        public DiscoExtensionLogger.LogLevel Level { get; set; }
        public string LevelString { get { return Level.ToString(); } }
    }
}
