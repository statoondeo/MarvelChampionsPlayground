public abstract class BaseShuffleComponentDecorator : BaseZoneComponentDecorator<IShuffleComponent>, IShuffleComponent
{
    #region ICoreZoneComponent

    private IShuffleComponent InnerComponent => Inner as IShuffleComponent;
    public virtual void Shuffle() => InnerComponent?.Shuffle();

    #endregion
}