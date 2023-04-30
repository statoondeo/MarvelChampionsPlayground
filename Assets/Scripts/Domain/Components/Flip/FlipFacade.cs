using System;

public sealed class FlipFacade : IFlipFacade
{
    private readonly IFacade<IFlipComponent> Facade;
    private FlipFacade(IFlipComponent item) => Facade = FacadeComponent<IFlipComponent>.Get(item);

    #region IFacade<IFlip>

    public IFlipComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IFlipComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IFlipComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IFlip

    public Action<IFlipComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public IRepository<string, ICoreFacade> Faces => Item.Faces;
    public ICoreFacade CurrentFace => Item.CurrentFace;
    public void FlipTo(string face) => Item.FlipTo(face);

    #endregion

    public static IFlipFacade Get(ICoreFacade face, ICoreFacade back) 
        => new FlipFacade(FlipComponent.Get(face, back));
}