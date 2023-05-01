public sealed class TreatThresholdFacade : BaseComponentFacade<ITreatThresholdComponent>, ITreatThresholdFacade
{
    private TreatThresholdFacade(ITreatThresholdComponent item) : base(item) { }

    #region ITreatThreshold

    public int TreatThreshold => Item.TreatThreshold;

    #endregion

    public static ITreatThresholdFacade Get(int TreatThreshold) 
        => new TreatThresholdFacade(TreatThresholdComponent.Get(TreatThreshold));
}