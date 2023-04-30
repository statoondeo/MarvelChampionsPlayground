using System;

public sealed class DefenseFacade : IDefenseFacade
{
    private readonly IFacade<IDefenseComponent> Facade;
    private DefenseFacade(IDefenseComponent item) => Facade = FacadeComponent<IDefenseComponent>.Get(item);

    #region IFacade<IDefense>

    public IDefenseComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IDefenseComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IDefenseComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IDefense

    public Action<IDefenseComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Defense => Item.Defense;

    #endregion

    public static IDefenseFacade Get(int Defense) => new DefenseFacade(DefenseComponent.Get(Defense));
}