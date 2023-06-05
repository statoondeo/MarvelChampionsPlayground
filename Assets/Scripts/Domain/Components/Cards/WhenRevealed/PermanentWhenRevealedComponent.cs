using System;

public sealed class PermanentWhenRevealedComponent : BaseWhenRevealedComponent
{
    private PermanentWhenRevealedComponent(Func<ICard, ICommand> commandFactory) : base(commandFactory) { }

    public static IWhenRevealedComponent Get(Func<ICard, ICommand> commandFactory)
        => new PermanentWhenRevealedComponent(commandFactory);
}
