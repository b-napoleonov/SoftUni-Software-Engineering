namespace CommandPattern.Core.Contracts.Commands
{
    public interface HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
