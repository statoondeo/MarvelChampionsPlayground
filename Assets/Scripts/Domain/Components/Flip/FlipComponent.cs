using System.Collections.Generic;

public sealed class FlipComponent : BaseComponent<IFlipComponent>, IFlipComponent
{
    public IList<IFace> Faces { get; private set; }
    public IFace CurrentFace { get; private set; }
    private FlipComponent(IFace face, IFace back)
        : base()
    {
        Faces = new List<IFace> { face, back };
        CurrentFace = face;
    }
    private FlipComponent(IFace faceA, IFace backA, IFace faceB, IFace backB)
    : this(faceA, backA)
    {
        Faces.Add(faceB);
        Faces.Add(backB);
    }
    private FlipComponent(IFace faceA, IFace backA, IFace faceB, IFace backB, IFace faceC, IFace backC)
    : this(faceA, backA, faceB, backB)
    {
        Faces.Add(faceC);
        Faces.Add(backC);
    }
    public bool IsFace(int face) => CurrentFace.Equals(Faces[face]);
    public void FlipTo(int face)
    {
        if (face == Faces.IndexOf(CurrentFace)) return;
        CurrentFace = Faces[face];
        Card.Raise<IFlipComponent>();
    }
    public void FlipToNext() => FlipTo((Faces.IndexOf(CurrentFace) + 1) % Faces.Count);
    public static IFlipComponent Get(IFace face, IFace back)
        => new FlipComponent(face, back);
    public static IFlipComponent Get(IFace faceA, IFace backA, IFace faceB, IFace backB)
        => new FlipComponent(faceA, backA, faceB, backB);
    public static IFlipComponent Get(IFace faceA, IFace backA, IFace faceB, IFace backB, IFace faceC, IFace backC)
        => new FlipComponent(faceA, backA, faceB, backB, faceC, backC);
}
