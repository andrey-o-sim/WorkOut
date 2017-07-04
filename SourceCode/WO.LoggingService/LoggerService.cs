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

        public void Debug(string messageFormat, params object[] parameters)
        {
            _logger.Debug(messageFormat, parameters);
        }

        public void Error(string messageFormat, params object[] parameters)
        {
            _logger.Error(messageFormat, parameters);
        }

        public void ErrorException(Exception exception, string messageFormat, params object[] parameters)
        {
            _logger.Error(exception, messageFormat, parameters);
        }

        public void Fatal(string messageFormat, params object[] parameters)
        {
            _logger.Fatal(messageFormat, parameters);
        }

        public void Fatal(Exception exception, string messageFormat, params object[] parameters)
        {
            _logger.Fatal(exception, messageFormat, parameters);
        }

        public void Info(string messageFormat, params object[] parameters)
        {
            _logger.Info(messageFormat, parameters);
        }

        public void Trace(string messageFormat, params object[] parameters)
        {
            _logger.Trace(messageFormat, parameters);
        }

        public void Warn(string messageFormat, params object[] parameters)
        {
            _logger.Warn(messageFormat, parameters);
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
