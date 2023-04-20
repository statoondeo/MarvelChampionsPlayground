public interface ITreatAcceleration { int TreatAcceleration { get; } }
public sealed class TreatAccelerationComponent : ITreatAcceleration
{
    public int TreatAcceleration { get; private set; }
    public TreatAccelerationComponent(int treatAcceleration) => TreatAcceleration = treatAcceleration;
}