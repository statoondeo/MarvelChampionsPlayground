using System.Collections.Generic;

public sealed class FlipFacade : BaseComponentFacade<IFlipComponent>, IFlipFacade
{
    private FlipFacade(IFlipComponent item) : base(item) { }

    #region IFlip

    public IDictionary<string, ICoreFacade> Faces => Item.Faces;
    public ICoreFacade CurrentFace => Item.CurrentFace;
    public void FlipTo(string face) => Item.FlipTo(face);

    #endregion

    public static IFlipFacade Get(ICoreFacade face, ICoreFacade back) 
        => new FlipFacade(FlipComponent.Get(face, back));
}