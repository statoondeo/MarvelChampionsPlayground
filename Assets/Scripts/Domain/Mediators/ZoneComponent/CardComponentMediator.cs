public sealed class CardComponentMediator : BaseMediator<ICardComponent>
{
    private CardComponentMediator() : base(CardComponentEvent.Get) { }
    public static IMediator<ICardComponent> Get() => new CardComponentMediator();
}