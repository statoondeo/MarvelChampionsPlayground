using System.Collections.Generic;

public sealed class FlipFacade : BaseCardComponentFacade<IFlipComponent>, IFlipFacade
{
    private FlipFacade(IFlipComponent item) : base(item) { }

    public IList<ICardFace> Faces => Item.Faces;
    public ICardFace CurrentFace => Item.CurrentFace;
    public void FlipTo(int face) => Item.FlipTo(face);
    public void FlipToNext() => Item.FlipToNext();
    public bool IsFace(int face) => Item.IsFace(face);
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        foreach (ICardFace face in Faces) face.SetCard(card);
    }
    public static IFlipFacade Get(ICardFace face, ICardFace back)
        => new FlipFacade(FlipComponent.Get(face, back));
    public static IFlipFacade Get(ICardFace faceA, ICardFace backA, ICardFace faceB, ICardFace backB)
        => new FlipFacade(FlipComponent.Get(faceA, backA, faceB, backB));
    public static IFlipFacade Get(ICardFace faceA, ICardFace backA, ICardFace faceB, ICardFace backB, ICardFace faceC, ICardFace backC)
        => new FlipFacade(FlipComponent.Get(faceA, backA, faceB, backB, faceC, backC));
}