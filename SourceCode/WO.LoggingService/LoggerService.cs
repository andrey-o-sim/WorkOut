using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WO.LoggerService
{
    public class LoggerService : ILoggerService
    {
        private Logger _logger;
        public LoggerService(Type sourceType)
        {
            if (sourceType == null)
            {
                throw new ArgumentNullException("'SourceType' = null. Provide execute class type");
            }

            _logger = LogManager.GetLogger(sourceType.FullName);
        }

        public LoggerService(Type sourceType, MethodBase sourceMethod)
        {
            _logger = LogManager.GetLogger(string.Format("{0}.{1}", sourceType.FullName, sourceMethod.Name));
        }

        public string Name => _logger.Name;

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void ErrorException(string message, Exception exception)
        {
            _logger.Error(exception, message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Fatal(string message, Exception exception)
        {
            _logger.Fatal(exception, message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Log(LogLevel level, string messageFormat, params object[] parameters)
        {
            _logger.Log(level, messageFormat, parameters);
        }

        public void Log(LogLevel level, IList<string> list)
        {
            _logger.Log(level, list);
        }

        public void Log(LogLevel level, string message, Exception exc)
        {
            _logger.Log(level, exc, message);
        }

        public void Log(LogLevel level, string messageFormat, Exception exc, params object[] parameters)
        {
            _logger.Log(level, messageFormat, exc, parameters);
        }


    }
}
