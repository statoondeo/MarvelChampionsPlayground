using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine;

public sealed class ResourceComponent : IResource
{
    private ResourceComponent(int energy, int mental, int physic, int wild)
    {
        Energy = energy;
        Mental = mental;
        Physic = physic;
        Wild = wild;
    }

    public int Energy { get; private set; }
    public int Mental { get; private set; }
    public int Physic { get; private set; }
    public int Wild { get; private set; }

    public static IResource Get(int energy, int mental, int physic, int wild) 
        => new ResourceComponent(energy, mental, physic, wild);
}
public interface IResourceFacade : IFacade<IResource>, IResource { }
public sealed class ResourceFacade : IResourceFacade
{
    private readonly IFacade<IResource> Facade;
    private ResourceFacade(IResource item) => Facade = FacadeComponent<IResource>.Get(item);

    #region IFacade<IResource>

    public IResource Item { get; private set; }
    public void AddDecorator(IDecorator<IResource> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IResource> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IResource

    public int Energy => Item.Energy;
    public int Mental => Item.Mental;
    public int Physic => Item.Physic;
    public int Wild => Item.Wild;

    #endregion

    public static IResourceFacade Get(int energy, int mental, int physic, int wild) 
        => new ResourceFacade(ResourceComponent.Get(energy, mental, physic, wild));
}