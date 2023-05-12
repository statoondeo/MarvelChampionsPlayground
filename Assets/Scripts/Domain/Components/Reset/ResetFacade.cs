public sealed class ResetFacade : BaseFacade<IResetComponent>, IResetFacade
{
    private ResetFacade(IResetComponent item)
        : base(item) { }
    public void Reset() => Item.Reset();
    public static IResetFacade Get(IResetComponent item)
        => new ResetFacade(item);
}
