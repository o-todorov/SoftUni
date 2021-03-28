using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Commands
{
    class CommandFactory : ICommandFactory
    {
        public ICommand Command(string commandType)
        {
            Type type = Assembly.GetEntryAssembly()
                                   .GetTypes()
                                   .FirstOrDefault(t => t.Name.Equals($"{commandType}Command"));

            if (type == null)
            {
                return null;
            }

            return (ICommand)Activator.CreateInstance(type);
        }
    }
}
