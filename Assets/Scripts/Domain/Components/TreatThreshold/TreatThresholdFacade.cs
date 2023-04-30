using System;

public sealed class TreatThresholdFacade : ITreatThresholdFacade
{
    private readonly IFacade<ITreatThresholdComponent> Facade;
    private TreatThresholdFacade(ITreatThresholdComponent item) 
        => Facade = FacadeComponent<ITreatThresholdComponent>.Get(item);

    #region IFacade<ITreatThreshold>

    public ITreatThresholdComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ITreatThresholdComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatThresholdComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ITreatThreshold

    public Action<ITreatThresholdComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int TreatThreshold => Item.TreatThreshold;

    #endregion

    public static ITreatThresholdFacade Get(int TreatThreshold) 
        => new TreatThresholdFacade(TreatThresholdComponent.Get(TreatThreshold));
}