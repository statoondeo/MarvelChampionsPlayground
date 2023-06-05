using System;

public sealed class InstantWhenRevealedComponent : BaseWhenRevealedComponent
{
    private InstantWhenRevealedComponent(Func<ICard, ICommand> commandFactory) : base(commandFactory) { }

    public static IWhenRevealedComponent Get(Func<ICard, ICommand> commandFactory)
        => new InstantWhenRevealedComponent(commandFactory);
}
