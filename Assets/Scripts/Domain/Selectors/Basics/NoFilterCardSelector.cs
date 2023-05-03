public sealed class NoFilterCardSelector : ISelector<ICard>
{
    private NoFilterCardSelector() { }
    public bool Match(ICard item) => true;
    private static ISelector<ICard> Selector;
    public static ISelector<ICard> Get() => Selector is null ? Selector = new NoFilterCardSelector() : Selector;
}
