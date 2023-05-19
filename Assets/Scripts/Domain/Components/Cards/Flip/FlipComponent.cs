using System.Collections.Generic;

public sealed class FlipComponent : BaseCardComponent<IFlipComponent>, IFlipComponent
{
    public IList<ICardFace> Faces { get; private set; }
    public ICardFace CurrentFace { get; private set; }
    private FlipComponent(ICardFace face, ICardFace back)
        : base()
    {
        Faces = new List<ICardFace> { face, back };
        CurrentFace = face;
    }
    private FlipComponent(ICardFace faceA, ICardFace backA, ICardFace faceB, ICardFace backB)
    : this(faceA, backA)
    {
        Faces.Add(faceB);
        Faces.Add(backB);
    }
    private FlipComponent(ICardFace faceA, ICardFace backA, ICardFace faceB, ICardFace backB, ICardFace faceC, ICardFace backC)
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
    public static IFlipComponent Get(ICardFace face, ICardFace back)
        => new FlipComponent(face, back);
    public static IFlipComponent Get(ICardFace faceA, ICardFace backA, ICardFace faceB, ICardFace backB)
        => new FlipComponent(faceA, backA, faceB, backB);
    public static IFlipComponent Get(ICardFace faceA, ICardFace backA, ICardFace faceB, ICardFace backB, ICardFace faceC, ICardFace backC)
        => new FlipComponent(faceA, backA, faceB, backB, faceC, backC);
}
