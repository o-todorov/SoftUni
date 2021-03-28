using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    internal class Engine : IEngine
    {
        private readonly ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            while (true)
            {
                string commandInput  = Console.ReadLine();
                string commandResult = command.Read(commandInput);

                if (commandResult == null)
                {
                    return;
                }

                Console.WriteLine(commandResult);
            }
        }
    }
}