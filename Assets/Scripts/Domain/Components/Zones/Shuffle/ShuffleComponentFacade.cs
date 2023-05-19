public sealed class ShuffleComponentFacade : BaseZoneComponentFacade<IShuffleComponent>, IShuffleComponentFacade
{
    #region Constructor

    private ShuffleComponentFacade(IShuffleComponent item) 
        : base(item) { }

    #endregion

    #region IShuffleComponent

    public void Shuffle() => Item.Shuffle();

    #endregion

    #region Factory

    public static IShuffleComponentFacade Get()
        => new ShuffleComponentFacade(ShuffleComponent.Get());

    #endregion
}
