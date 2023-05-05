public sealed class TreatStartFacade : BaseFacade<ITreatStartComponent>, ITreatStartFacade
{
    private TreatStartFacade(ITreatStartComponent item) : base(item) { }
    public int TreatStart => Item.TreatStart;
    public static ITreatStartFacade Get(int TreatStart) => new TreatStartFacade(TreatStartComponent.Get(TreatStart));
}