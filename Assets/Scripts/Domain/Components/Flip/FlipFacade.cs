using System.Collections.Generic;

public sealed class FlipFacade : BaseFacade<IFlipComponent>, IFlipFacade
{
    private FlipFacade(IFlipComponent item) : base(item) { }
    public IDictionary<string, ICoreFacade> Faces => Item.Faces;
    public ICoreFacade CurrentFace => Item.CurrentFace;
    public void FlipTo(string face) => Item.FlipTo(face);
    public static IFlipFacade Get(ICoreFacade face, ICoreFacade back) 
        => new FlipFacade(FlipComponent.Get(face, back));
}