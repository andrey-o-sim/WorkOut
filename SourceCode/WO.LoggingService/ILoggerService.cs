using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WO.LoggerService
{
    public interface ILoggerService
    {
        string Name { get; }
        void Debug(string messageFormat, params object[] parameters);
        void Trace(string messageFormat, params object[] parameters);
        void Info(string messageFormat, params object[] parameters);
        void Warn(string messageFormat, params object[] parameters);
        void Error(string messageFormat, params object[] parameters);
        void ErrorException(Exception exception, string messageFormat, params object[] parameters);
        void Fatal(string messageFormat, params object[] parameters);
        void Fatal(Exception exception, string messageFormat, params object[] parameters);
        void Log(LogLevel level, string format, params object[] parameters);
        void Log(LogLevel level, IList<string> list);
        void Log(LogLevel level, string message, Exception exc);
        void Log(LogLevel level, string format, Exception exc, params object[] parameters);
    }
}
