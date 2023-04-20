public interface IResource
{
    int Energy { get; }
    int Mental { get; }
    int Physic { get; }
    int Wild { get; }
}
public sealed class ResourceComponent : IResource
{
    public ResourceComponent(int energy, int mental, int physic, int wild)
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
}