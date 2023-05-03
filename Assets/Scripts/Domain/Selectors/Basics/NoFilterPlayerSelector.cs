public sealed class NoFilterPlayerSelector : ISelector<IPlayer>
{
    private NoFilterPlayerSelector() { }
    public bool Match(IPlayer item) => true;
    private static ISelector<IPlayer> Selector;
    public static ISelector<IPlayer> Get() => Selector is null ? Selector = new NoFilterPlayerSelector() : Selector;
}
