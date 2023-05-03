public abstract class BaseFunctionalCommand : BaseCommand
{
    protected BaseFunctionalCommand(IGame game) : base(game) { }
    protected virtual ISelector<ICard> GetCardSelector() => NoFilterCardSelector.Get();
    protected virtual ISelector<ICard> GetPlayerChoices() => NoFilterCardSelector.Get();
    protected virtual ICommand GetCardCommand(ICard card) => NullCommand.Get();
    protected virtual ICommand GetAdditionalCommand() => NullCommand.Get();
    public override void Execute()
    {        
        foreach (ICard card in Game.GetAll(AndCompositeSelector.Get(GetCardSelector(), GetPlayerChoices())))
            GetCardCommand(card).Execute();
        GetAdditionalCommand().Execute();
    }
}
