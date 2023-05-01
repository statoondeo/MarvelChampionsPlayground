public sealed class TreatStartFacade : BaseComponentFacade<ITreatStartComponent>, ITreatStartFacade
{
    private TreatStartFacade(ITreatStartComponent item) : base(item) { }

    #region ITreatStart

    public int TreatStart => Item.TreatStart;

    #endregion

    public static ITreatStartFacade Get(int TreatStart) => new TreatStartFacade(TreatStartComponent.Get(TreatStart));
}