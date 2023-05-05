public sealed class ResourceGeneratorComponent 
    : BaseComponent<IResourceGeneratorComponent>, IResourceGeneratorComponent
{
    private ResourceGeneratorComponent(int energy, int mental, int physic, int wild)
        : base()
    {
        Type = ComponentType.ResourceGenerator;
        Energy = energy;
        Mental = mental;
        Physic = physic;
        Wild = wild;
    }

    public int Energy { get; private set; }
    public int Mental { get; private set; }
    public int Physic { get; private set; }
    public int Wild { get; private set; }

    public static IResourceGeneratorComponent Get(int energy, int mental, int physic, int wild) 
        => new ResourceGeneratorComponent(energy, mental, physic, wild);
}
