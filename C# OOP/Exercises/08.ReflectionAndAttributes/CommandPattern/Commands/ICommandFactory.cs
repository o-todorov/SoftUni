using CommandPattern.Core.Contracts;

namespace CommandPattern.Commands
{
    interface ICommandFactory
    {
        ICommand Command(string commandType);
    }
}
