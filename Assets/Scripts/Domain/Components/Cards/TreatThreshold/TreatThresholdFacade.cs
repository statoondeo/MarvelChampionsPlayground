public sealed class TreatThresholdFacade : BaseCardComponentFacade<ITreatThresholdComponent>, ITreatThresholdFacade
{
    private TreatThresholdFacade(ITreatThresholdComponent item) : base(item) { }
    public int TreatThreshold => Item.TreatThreshold;
    public static ITreatThresholdFacade Get(int TreatThreshold) 
        => new TreatThresholdFacade(TreatThresholdComponent.Get(TreatThreshold));
}