using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern.Commands
{
    class CommandInterpreter : ICommandInterpreter
    {
        private readonly ICommandFactory commandFactory;

        public CommandInterpreter()
        {
            this.commandFactory = new CommandFactory();
        }

        public string Read(string args)
        {
            string[]    commandInput    = args.Split();
            string      commandType     = commandInput[0];
            string[]    commandArgs     = commandInput.Skip(1).ToArray();
            ICommand    command         = commandFactory.Command(commandType);

            return command == null ? null : command.Execute(commandArgs);
        }
    }
}
