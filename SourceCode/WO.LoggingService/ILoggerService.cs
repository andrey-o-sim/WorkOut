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
        void Debug(string message);
        void Trace(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void ErrorException(string message, Exception exception);
        void Fatal(string message);
        void Fatal(string message, Exception exception);
        void Log(LogLevel level, String format, params object[] parameters);
        void Log(LogLevel level, IList<String> list);
        void Log(LogLevel level, String message, Exception exc);
        void Log(LogLevel level, String format, Exception exc, params object[] parameters);
    }
}
