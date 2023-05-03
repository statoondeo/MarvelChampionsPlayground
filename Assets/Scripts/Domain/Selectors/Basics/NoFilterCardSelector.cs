public sealed class NoFilterCardSelector : ISelector<ICard>
{
    private NoFilterCardSelector() { }
    public bool Match(ICard item) => true;
    public static ISelector<ICard> Get() => new NoFilterCardSelector();
}
