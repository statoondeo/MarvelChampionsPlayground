public sealed class TreatAccelerationComponent 
    : BaseCardComponent<ITreatAccelerationComponent>, 
        ITreatAccelerationComponent
{
    public int TreatAcceleration { get; private set; }
    private TreatAccelerationComponent(int treatAcceleration)
        : base()
    {
        TreatAcceleration = treatAcceleration;
    }
    public static ITreatAccelerationComponent Get(int treatAcceleration) 
        => new TreatAccelerationComponent(treatAcceleration);
}
