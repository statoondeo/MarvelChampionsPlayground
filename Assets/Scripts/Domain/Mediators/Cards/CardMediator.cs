public sealed class CardMediator : BaseMediator<ComponentType, ICard>, ICardMediator
{
    private ICard Card;
    private CardMediator() : base(CardEventHandler.Get) { }
    public void SetCard(ICard card) => Card = card;
    public override void Raise(ComponentType eventName) => Raise(eventName, Card);

    public static ICardMediator Get() => new CardMediator();
}
