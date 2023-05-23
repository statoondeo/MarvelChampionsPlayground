using System.Collections.Generic;
using System.Linq;

public abstract class BaseFunctionalCommand : BaseCommand
{
    protected BaseFunctionalCommand(IGame game) : base(game) { }
    protected virtual ISelector<ICard> CardSelector => NoFilterCardSelector.Get();
    protected virtual IPicker<ICard> CardPicker => NoCardPicker.Get();
    protected virtual ICommand GetCardCommand(ICard card) => NullCommand.Get();
    protected virtual ICommand GetAdditionalCommand() => NullCommand.Get();
    public override void Execute()
    {        
        IEnumerable<ICard> cards = CardPicker.Pick(Game.GetAll(CardSelector));
        if ((cards is not null) && (cards.Count() > 0))
            foreach (ICard card in cards)
                GetCardCommand(card)?.Execute();
        GetAdditionalCommand().Execute();
    }
}
