public sealed class NoFilterSelector : ISelector<ICard>
{
    private NoFilterSelector() { }
    public bool Match(ICard card) => true;
    public static ISelector<ICard> Get() => new NoFilterSelector();
}
