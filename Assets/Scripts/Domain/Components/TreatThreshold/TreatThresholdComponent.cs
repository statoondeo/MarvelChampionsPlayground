public sealed class TreatThresholdComponent : BaseComponent<ITreatThresholdComponent>, ITreatThresholdComponent
{
    public int TreatThreshold { get; private set; }
    private TreatThresholdComponent(int treatThreshold)
        : base()
    {
        Type = ComponentType.TreatThreshold;
        TreatThreshold = treatThreshold;
    }
    public static ITreatThresholdComponent Get(int treatThreshold) 
        => new TreatThresholdComponent(treatThreshold);
}
