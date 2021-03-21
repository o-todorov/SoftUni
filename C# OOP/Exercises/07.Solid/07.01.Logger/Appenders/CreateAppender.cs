using Solid.Layouts;
using System;

namespace Solid.Appenders
{
    class CreateAppender
    {
        public static IAppender GetAppender(string appenderType, ILayout layout)
        {
            if (appenderType == nameof(ConsoleAppender))
            {
                return new ConsoleAppender(layout);
            }
            else if (appenderType == nameof(FileAppender))
            {
                return new FileAppender(layout, new LogFile());
            }
            else
            {
                throw new ArgumentException($"Appender type: {appenderType} unknown");
            }
        }

    }
}
