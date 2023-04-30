using System;

public sealed class SchemeFacade : ISchemeFacade
{
    private readonly IFacade<ISchemeComponent> Facade;
    private SchemeFacade(ISchemeComponent item) => Facade = FacadeComponent<ISchemeComponent>.Get(item);

    #region IFacade<IScheme>

    public ISchemeComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ISchemeComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISchemeComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IScheme

    public Action<ISchemeComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Scheme => Item.Scheme;

    #endregion

    public static ISchemeFacade Get(int Scheme) => new SchemeFacade(SchemeComponent.Get(Scheme));
}