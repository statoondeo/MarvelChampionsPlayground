public sealed class NoFilterPlayerSelector : ISelector<IPlayer>
{
    private NoFilterPlayerSelector() { }
    public bool Match(IPlayer item) => true;
    public static ISelector<IPlayer> Get() => new NoFilterPlayerSelector();
}
