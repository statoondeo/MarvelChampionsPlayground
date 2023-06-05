public sealed class TreatAccelerationFacade : 
    BaseCardComponentFacade<ITreatAccelerationComponent>, 
    ITreatAccelerationFacade
{
    private TreatAccelerationFacade(ITreatAccelerationComponent item) 
        : base(item) { }
    public int TreatAcceleration 
        => Item.TreatAcceleration;
    public static ITreatAccelerationFacade Get(int TreatAcceleration) 
        => new TreatAccelerationFacade(TreatAccelerationComponent.Get(TreatAcceleration));
}
