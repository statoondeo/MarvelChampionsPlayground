using System;

public sealed class ResourceGeneratorFacade : IResourceGeneratorFacade
{
    private readonly IFacade<IResourceGeneratorComponent> Facade;
    private ResourceGeneratorFacade(IResourceGeneratorComponent item) 
        => Facade = FacadeComponent<IResourceGeneratorComponent>.Get(item);

    #region IFacade<IResource>

    public IResourceGeneratorComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IResourceGeneratorComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IResourceGeneratorComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IResource

    public Action<IResourceGeneratorComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Energy => Item.Energy;
    public int Mental => Item.Mental;
    public int Physic => Item.Physic;
    public int Wild => Item.Wild;

    #endregion

    public static IResourceGeneratorFacade Get(int energy, int mental, int physic, int wild) 
        => new ResourceGeneratorFacade(ResourceGeneratorComponent.Get(energy, mental, physic, wild));
}