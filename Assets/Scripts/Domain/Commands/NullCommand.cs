using System;

public sealed class NullCommand : BaseSingleCommand
{
    private NullCommand(IGame game) : base(game) { }
    public static ICommand Get(IGame game) => new NullCommand(game);
    public static Func<ICard, ICommand> GetFactory(IGame game) => (card) => Get(game);
}
