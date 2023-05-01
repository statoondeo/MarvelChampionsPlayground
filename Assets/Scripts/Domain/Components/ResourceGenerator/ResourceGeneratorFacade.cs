public sealed class ResourceGeneratorFacade : BaseComponentFacade<IResourceGeneratorComponent>, IResourceGeneratorFacade
{
    private ResourceGeneratorFacade(IResourceGeneratorComponent item) : base(item) { }

    #region IResource

    public int Energy => Item.Energy;
    public int Mental => Item.Mental;
    public int Physic => Item.Physic;
    public int Wild => Item.Wild;

    #endregion

    public static IResourceGeneratorFacade Get(int energy, int mental, int physic, int wild) 
        => new ResourceGeneratorFacade(ResourceGeneratorComponent.Get(energy, mental, physic, wild));
}