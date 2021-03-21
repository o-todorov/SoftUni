using Solid.Core;
using Solid.Layouts;
using System;

namespace Solid.Appenders
{
    class ConsoleAppender :Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout) { }

        protected override void Append(string dateTime, ReportLevel level, string text)
        {
            string output = string.Format(layout.Template, dateTime, level, text);

            Console.WriteLine(output);
        }
    }
}