
using Solid.Core;
using Solid.Layouts;
using System;

namespace Solid.Appenders
{
    abstract class Appender : IAppender
    {
        protected ILayout layout;
        private int messagesCount;
        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }
        public ReportLevel ReportLevel { get; set; }
        protected abstract void Append(string dateTime, ReportLevel level, string text);
        public void AppendMessage(string dateTime, ReportLevel level, string text) 
        {
            if (level < ReportLevel)
            {
                return;
            }

            Append(dateTime, level, text);
            messagesCount++;
        }

        public void AppendMessage(DateTime dateTime, ReportLevel level, string text)
        {
            AppendMessage(dateTime.ToString(), level, text);
        }
        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.messagesCount}";
        }
    }
}
