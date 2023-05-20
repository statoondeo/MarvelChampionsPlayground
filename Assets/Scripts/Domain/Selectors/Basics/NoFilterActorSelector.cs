public sealed class NoFilterActorSelector : ISelector<IActor>
{
    private NoFilterActorSelector() { }
    public bool Match(IActor item) => true;
    private static ISelector<IActor> Selector;
    public static ISelector<IActor> Get() => Selector is null ? Selector = new NoFilterActorSelector() : Selector;
}
