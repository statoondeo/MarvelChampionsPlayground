using System;

public sealed class StaticWhenRevealedComponent : BaseWhenRevealedComponent
{
    private StaticWhenRevealedComponent(Func<ICard, ICommand> commandFactory) : base(commandFactory) { }

    public static IWhenRevealedComponent Get(Func<ICard, ICommand> commandFactory)
        => new StaticWhenRevealedComponent(commandFactory);
}
