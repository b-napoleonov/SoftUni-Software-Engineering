using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = tokens[0] + "Command";
            string[] parameters = tokens.Skip(1).ToArray();

            Type type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => t.Name == commandName)
                .FirstOrDefault();

            if (type == null)
            {
                throw new InvalidOperationException("Invalid command");
            }

            ICommand command = (ICommand)Activator.CreateInstance(type);
            string result = command.Execute(parameters);

            return result;
        }
    }
}
