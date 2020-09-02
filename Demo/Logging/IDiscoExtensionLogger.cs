using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Logging
{
    public interface IDiscoExtensionLogger
    {
        void LogDebug(string msg);
        void LogInfo(string msg);
        void LogError(string msg);
        void LogCritical(string msg);
        
    }
}
