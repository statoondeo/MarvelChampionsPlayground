using System.Collections.Generic;

public sealed class FlipComponent : BaseComponent<IFlipComponent>, IFlipComponent
{
    public IDictionary<string, IFace> Faces { get; private set; }
    public IFace CurrentFace { get; private set; }
    private FlipComponent(IFace face, IFace back)
        : base()
    {
        Faces = new Dictionary<string, IFace>
        {
            { "FACE", face },
            { "BACK", back }
        };
        CurrentFace = face;
    }
    public bool IsFace(string face) => CurrentFace.Equals(Faces[face]);
    public void FlipTo(string face)
    {
        if (!Faces.TryGetValue(face, out IFace newFace)) return;
        if (CurrentFace.Equals(newFace)) return;
        CurrentFace = newFace;
        Card.Raise<IFlipComponent>();
    }
    public static IFlipComponent Get(IFace face, IFace back)
        => new FlipComponent(face, back);
}
