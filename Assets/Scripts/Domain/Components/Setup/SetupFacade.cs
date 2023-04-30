using System;

public sealed class SetupFacade : ISetupFacade
{
    private readonly IFacade<ISetupComponent> Facade;
    private SetupFacade(ISetupComponent item) => Facade = FacadeComponent<ISetupComponent>.Get(item);

    #region IFacade<ISetup>

    public ISetupComponent Item { get; private set; }
    public void AddDecorator(IDecorator<ISetupComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<ISetupComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region ISetup

    public Action<ISetupComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public ICommand Setup => Item.Setup;

    #endregion

    public static ISetupFacade Get(ICommand command) => new SetupFacade(SetupComponent.Get(command));
}