public sealed class CardEventHandler : BaseEventHandler<ICard>
{
    private CardEventHandler() : base() { }
    public static IEventHandler<ICard> Get() => new CardEventHandler();
}