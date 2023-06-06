public sealed class NoFilterCardControllerSelector : ISelector<BaseCardController>
{
    private NoFilterCardControllerSelector() { }
    public bool Match(BaseCardController item) => true;
    public static ISelector<BaseCardController> Get() => new NoFilterCardControllerSelector();
}
