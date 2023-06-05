using System;

public abstract class BaseWhenRevealedComponent : BaseCardComponent<IWhenRevealedComponent>, IWhenRevealedComponent
{
    protected BaseWhenRevealedComponent(Func<ICard, ICommand> commandFactory) : base() => CommandFactory = commandFactory;
    private readonly Func<ICard, ICommand> CommandFactory;
    private ICommand Command;
    public ICommand WhenRevealed => Command is null ? Command = CommandFactory.Invoke(Card) : Command;
}