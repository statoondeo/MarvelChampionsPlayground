using System;

public sealed class NullCommand : ICommand
{
    private NullCommand() { }
    public void Execute() { }
    public static ICommand Get() => new NullCommand();
    public static Func<ICard, ICommand> GetFactory() => (card) => new NullCommand();
}
