using System.Collections.Generic;

public sealed class FlipFacade : BaseFacade<IFlipComponent>, IFlipFacade
{
    private FlipFacade(IFlipComponent item) : base(item) { }
    public IDictionary<string, IFace> Faces => Item.Faces;
    public IFace CurrentFace => Item.CurrentFace;
    public void FlipTo(string face) => Item.FlipTo(face);
    public static IFlipFacade Get(IFace face, IFace back) 
        => new FlipFacade(FlipComponent.Get(face, back));
    public override void SetCard(ICard card)
    {
        base.SetCard(card);
        foreach (IFace face in Faces.Values) face.SetCard(card);
    }
}