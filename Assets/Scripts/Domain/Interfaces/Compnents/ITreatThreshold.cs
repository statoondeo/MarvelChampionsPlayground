public interface ITreatThreshold { int TreatThreshold { get; } }
public sealed class TreatThresholdComponent : ITreatThreshold
{
    public int TreatThreshold { get; private set; }
    public TreatThresholdComponent(int treatThreshold) => TreatThreshold = treatThreshold;
}