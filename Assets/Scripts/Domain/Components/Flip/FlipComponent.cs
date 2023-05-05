using System.Collections.Generic;

public sealed class FlipComponent : BaseComponent<IFlipComponent>, IFlipComponent
{
    public IDictionary<string, ICoreFacade> Faces { get; private set; }
    public ICoreFacade CurrentFace { get; private set; }
    private FlipComponent(ICoreFacade face, ICoreFacade back)
        : base()
    {
        Type = ComponentType.Flip;
        Faces = new Dictionary<string, ICoreFacade>
        {
            { "FACE", face },
            { "BACK", back }
        };
        CurrentFace = face;
    }
    public void FlipTo(string face)
    {
        if (!Faces.TryGetValue(face, out ICoreFacade newFace)) return;
        if (CurrentFace == newFace) return;
        CurrentFace = newFace;
        Card.Raise(Type);
    }
    public static IFlipComponent Get(ICoreFacade face, ICoreFacade back)
        => new FlipComponent(face, back);
}
