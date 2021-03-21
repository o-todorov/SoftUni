using Solid.Appenders;
using Solid.Core;
using Solid.Layouts;
using Solid.Readers;
using System;
using System.Collections.Generic;

namespace Solid
{
    class Engine : IEngine
    {
        private readonly IReader reader;
        public Engine(IReader reader)
        {
            this.reader = reader;
        }

        public void Run()
        {
            int count = int.Parse(reader.ReadLine());

            List<IAppender>     appenders           = ReadAppenders(count);
            ILogger             logger              = new Logger(appenders.ToArray());
            List<Command>       commands            = ReadCommands();
            commands.ForEach(c => Execute(c, logger));
            Console.WriteLine("Logger info");
            appenders.ForEach(Console.WriteLine);
        }

        private void Execute(Command command, ILogger logger)
        {
            switch (command.Report)
            {
                case ReportLevel.Info:
                    logger.Info(command.Date, command.Message);
                    break;
                case ReportLevel.Warning:
                    logger.Warning(command.Date, command.Message);
                    break;
                case ReportLevel.Error:
                    logger.Error(command.Date, command.Message);
                    break;
                case ReportLevel.Critical:
                    logger.Critical(command.Date, command.Message);
                    break;
                case ReportLevel.Fatal:
                    logger.Fatal(command.Date, command.Message);
                    break;
                default:
                    break;
            }
        }

        private List<Command> ReadCommands()
        {
            List<Command> commands = new List<Command>();
            string[] inputData;

            while ((inputData = reader.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries))[0].ToLower() != "end")
            {
                commands.Add(new Command()
                {
                    Date    = inputData[1],
                    Report  = Enum.Parse<ReportLevel>(inputData[0], true),
                    Message = inputData[2]
                });
            }

            return commands;
        }

        private List<IAppender> ReadAppenders(int count)
        {
            var appenders = new List<IAppender>();

            for (int i = 0; i < count; i++)
            {
                string[]    inputData   = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                ILayout     layout      = CreateLayout.GetLayout(inputData[1]);
                IAppender   appender    = CreateAppender.GetAppender(inputData[0], layout);
                appender.ReportLevel    = (inputData.Length == 3) ? Enum.Parse<ReportLevel>(inputData[2], true) : ReportLevel.Info;

                appenders.Add(appender);
            }

            return appenders;
        }



    }
}
