public abstract class BaseFunctionalCommand : BaseCommand
{
    protected BaseFunctionalCommand(IGame game) : base(game) { }
    protected virtual ISelector<ICard> CardSelector => NoFilterCardSelector.Get();
    protected virtual IPicker<ICard> CardPicker => NoCardPicker.Get();
    protected virtual ICommand GetCardCommand(ICard card) => NullCommand.Get();
    protected virtual ICommand GetAdditionalCommand() => NullCommand.Get();
    public override void Execute()
    {        
        foreach (ICard card in CardPicker.Pick(Game.GetAll(CardSelector)))
            GetCardCommand(card).Execute();
        GetAdditionalCommand().Execute();
    }
}
