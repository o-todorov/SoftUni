using Solid.Core;
using Solid.Layouts;

namespace Solid.Appenders
{
    class FileAppender : Appender, IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this.logFile = logFile;
        }

        protected override void Append(string dateTime, ReportLevel level, string text)
        {
            string output = string.Format(layout.Template, dateTime, level, text);

            logFile.Write(output);
        }
        public override string ToString()
        {
            return base.ToString() + $", File size {this.logFile.Size}";
        }
    }
}
