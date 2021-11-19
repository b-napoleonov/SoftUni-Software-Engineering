using System;

namespace CommandPattern.Core.Contracts.Commands
{
    public interface ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
