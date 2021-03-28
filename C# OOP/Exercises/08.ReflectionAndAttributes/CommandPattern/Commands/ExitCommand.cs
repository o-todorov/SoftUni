using CommandPattern.Core.Contracts;

namespace CommandPattern.Commands
{
    class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
