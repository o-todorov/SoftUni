using Solid.Appenders;
using Solid.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid
{
    class Logger:ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public void Info(string dateTime, string message)
        {
            var logMessage = LogMessage(dateTime, ReportLevel.Info, message);
            appenders.ForEach(logMessage);
        }
        public void Warning(string dateTime, string message)
        {
            var logMessage = LogMessage(dateTime, ReportLevel.Warning, message);
            appenders.ForEach(logMessage);
        }
        public void Error(string dateTime, string message)
        {
            var logMessage = LogMessage(dateTime, ReportLevel.Error, message);
            appenders.ForEach(logMessage);
        }
        public void Critical(string dateTime, string message)
        {
            var logMessage = LogMessage(dateTime, ReportLevel.Critical, message);
            appenders.ForEach(logMessage);
        }
        public void Fatal(string dateTime, string message)
        {
            var logMessage = LogMessage(dateTime, ReportLevel.Fatal, message);
            appenders.ForEach(logMessage);
        }
        private Action<IAppender> LogMessage(string dateTime, ReportLevel level, string message)
        {
            Action<IAppender> log = appender => appender.AppendMessage(dateTime, level, message);

            return log;
        }
    }
}
