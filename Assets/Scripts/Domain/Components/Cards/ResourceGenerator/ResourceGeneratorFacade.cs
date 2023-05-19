public sealed class ResourceGeneratorFacade : BaseCardComponentFacade<IResourceGeneratorComponent>, IResourceGeneratorFacade
{
    private ResourceGeneratorFacade(IResourceGeneratorComponent item) : base(item) { }
    public int Energy => Item.Energy;
    public int Mental => Item.Mental;
    public int Physic => Item.Physic;
    public int Wild => Item.Wild;
    public static IResourceGeneratorFacade Get(int energy, int mental, int physic, int wild) 
        => new ResourceGeneratorFacade(ResourceGeneratorComponent.Get(energy, mental, physic, wild));
}