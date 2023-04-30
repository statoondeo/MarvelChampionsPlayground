public interface IFlipComponent : IComponent<IFlipComponent>
{
    ICoreFacade CurrentFace { get; }
    IRepository<string, ICoreFacade> Faces { get; }
    void FlipTo(string face);
}
