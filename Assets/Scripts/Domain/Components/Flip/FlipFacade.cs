using System.Collections.Generic;

public sealed class FlipFacade : BaseFacade<IFlipComponent>, IFlipFacade
{
    private FlipFacade(IFlipComponent item) : base(item) { }

    public IList<IFace> Faces => Item.Faces;
    public IFace CurrentFace => Item.CurrentFace;
    public void FlipTo(int face) => Item.FlipTo(face);
    public void FlipToNext() => Item.FlipToNext();
    public bool IsFace(int face) => Item.IsFace(face);
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        foreach (IFace face in Faces) face.SetCard(card);
    }
    public static IFlipFacade Get(IFace face, IFace back)
        => new FlipFacade(FlipComponent.Get(face, back));
    public static IFlipFacade Get(IFace faceA, IFace backA, IFace faceB, IFace backB)
        => new FlipFacade(FlipComponent.Get(faceA, backA, faceB, backB));
    public static IFlipFacade Get(IFace faceA, IFace backA, IFace faceB, IFace backB, IFace faceC, IFace backC)
        => new FlipFacade(FlipComponent.Get(faceA, backA, faceB, backB, faceC, backC));
}