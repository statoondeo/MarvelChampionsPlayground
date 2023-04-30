public interface IResourceGeneratorComponent : IComponent<IResourceGeneratorComponent>
{
    int Energy { get; }
    int Mental { get; }
    int Physic { get; }
    int Wild { get; }
}
