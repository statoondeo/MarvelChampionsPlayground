public sealed class NoFilterBaseZoneControllerSelector : ISelector<BaseZoneController>
{
    private NoFilterBaseZoneControllerSelector() { }
    public bool Match(BaseZoneController item) => true;
    public static ISelector<BaseZoneController> Get() => new NoFilterBaseZoneControllerSelector();
}
