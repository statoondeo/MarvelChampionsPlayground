public abstract class EventModelArg
{
    public static EventModelArg Empty;
    protected EventModelArg() { }
}
public sealed class OnAddedEventModelArg : EventModelArg
{
    public string ToZone { get; private set; }
    public ICard Card { get; private set; }
    public OnAddedEventModelArg(string toZone, ICard card)
    {
        ToZone = toZone;
        Card = card;
    }
}
public sealed class OnRemovedEventModelArg : EventModelArg
{
    public string FromZone { get; private set; }
    public ICard Card { get; private set; }
    public OnRemovedEventModelArg(string fromZone, ICard card)
    {
        FromZone = fromZone;
        Card = card;
    }
}
//public sealed class ClickEventModelArg : EventModelArg
//{
//    public CardController Card { get; private set; }
//    public ClickEventModelArg(CardController card) => Card = card;
//}
//public sealed class SelectionEventModelArg : EventModelArg
//{
//    public CardController Card { get; private set; }
//    public SelectionEventModelArg(CardController card) => Card = card;
//}