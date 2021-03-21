using Solid.Core;
using System;

namespace Solid.Appenders
{
    internal interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        void AppendMessage(string dateTime, ReportLevel level, string text);
        void AppendMessage(DateTime dateTime, ReportLevel level, string text);
    }
}