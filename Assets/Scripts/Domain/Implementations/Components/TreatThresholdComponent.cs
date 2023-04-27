public sealed class TreatThresholdComponent : ITreatThreshold
{
    public int TreatThreshold { get; private set; }
    private TreatThresholdComponent(int treatThreshold) => TreatThreshold = treatThreshold;
    public static ITreatThreshold Get(int treatThreshold) => new TreatThresholdComponent(treatThreshold);
}