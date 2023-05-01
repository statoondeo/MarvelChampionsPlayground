public sealed class FlipComponent : BaseComponent<IFlipComponent>, IFlipComponent
{
    public IRepository<string, ICoreFacade> Faces { get; private set; }
    public ICoreFacade CurrentFace { get; private set; }
    private FlipComponent(ICoreFacade face, ICoreFacade back)
        : base()
    {
        Faces = new Repository<string, ICoreFacade>();
        CurrentFace = Faces.Register("FACE", face);
        Faces.Register("BACK", back);
    }
    public void FlipTo(string face)
    {
        if (!Faces.TryGetValue(face, out ICoreFacade newFace)) return;
        if (CurrentFace == newFace) return;
        CurrentFace = newFace;
        Notify(this);
    }
    public static IFlipComponent Get(ICoreFacade face, ICoreFacade back)
        => new FlipComponent(face, back);
}
