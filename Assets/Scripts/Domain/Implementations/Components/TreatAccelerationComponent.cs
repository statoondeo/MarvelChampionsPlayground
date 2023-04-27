public sealed class TreatAccelerationComponent : ITreatAcceleration
{
    public int TreatAcceleration { get; private set; }
    private TreatAccelerationComponent(int treatAcceleration) => TreatAcceleration = treatAcceleration;
    public static ITreatAcceleration Get(int treatAcceleration) => new TreatAccelerationComponent(treatAcceleration);
}