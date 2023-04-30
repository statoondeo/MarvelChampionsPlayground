using System;

public sealed class TreatStartFacade : ITreatStartFacade
{
    private readonly IFacade<ITreatStartComponent> Facade;
    private TreatStartFacade(ITreatStartComponent item) => Facade = FacadeComponent<ITreatStartComponent>.Get(item);

    #region IFacade<ITreatStart>

    public ITreatStartComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ITreatStartComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ITreatStartComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ITreatStart

    public Action<ITreatStartComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int TreatStart => Item.TreatStart;

    #endregion

    public static ITreatStartFacade Get(int TreatStart) => new TreatStartFacade(TreatStartComponent.Get(TreatStart));
}