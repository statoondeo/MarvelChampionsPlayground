using System;

public sealed class TreatAccelerationFacade : ITreatAccelerationFacade
{
    private readonly IFacade<ITreatAccelerationComponent> Facade;
    private TreatAccelerationFacade(ITreatAccelerationComponent item) 
        => Facade = FacadeComponent<ITreatAccelerationComponent>.Get(item);

    #region IFacade<ITreatAcceleration>

    public ITreatAccelerationComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ITreatAccelerationComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatAccelerationComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ITreatAcceleration

    public Action<ITreatAccelerationComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int TreatAcceleration => Item.TreatAcceleration;

    #endregion

    public static ITreatAccelerationFacade Get(int TreatAcceleration) 
        => new TreatAccelerationFacade(TreatAccelerationComponent.Get(TreatAcceleration));
}