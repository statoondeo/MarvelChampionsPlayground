public sealed class TreatAccelerationFacade : 
    BaseComponentFacade<ITreatAccelerationComponent>, 
    ITreatAccelerationFacade
{
    private TreatAccelerationFacade(ITreatAccelerationComponent item) 
        : base(item) { }

    #region ITreatAcceleration

    public int TreatAcceleration 
        => Item.TreatAcceleration;

    #endregion

    public static ITreatAccelerationFacade Get(int TreatAcceleration) 
        => new TreatAccelerationFacade(TreatAccelerationComponent.Get(TreatAcceleration));
}