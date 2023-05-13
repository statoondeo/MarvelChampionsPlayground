public sealed class TreatThresholdComponent : BaseComponent<ITreatThresholdComponent>, ITreatThresholdComponent
{
    public int TreatThreshold { get; private set; }
    private TreatThresholdComponent(int treatThreshold)
        : base()
    {
        TreatThreshold = treatThreshold;
    }
    public static ITreatThresholdComponent Get(int treatThreshold) 
        => new TreatThresholdComponent(treatThreshold);
}
