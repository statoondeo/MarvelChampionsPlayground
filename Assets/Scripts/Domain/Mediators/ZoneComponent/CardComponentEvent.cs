public sealed class CardComponentEvent : BaseEvent<ICardComponent>
{
    private CardComponentEvent() : base() { }
    public static IEvent<ICardComponent> Get() => new CardComponentEvent();
}