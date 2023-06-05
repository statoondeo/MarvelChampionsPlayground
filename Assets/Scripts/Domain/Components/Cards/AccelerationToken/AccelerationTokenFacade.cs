public sealed class AccelerationTokenFacade :
    BaseCardComponentFacade<IAccelerationTokenComponent>,
    IAccelerationTokenFacade
{
    private AccelerationTokenFacade(IAccelerationTokenComponent item)
        : base(item) { }
    public int AccelerationToken => Item.AccelerationToken;
    public static IAccelerationTokenFacade Get(int tokenAcceleration)
        => new AccelerationTokenFacade(AccelerationTokenComponent.Get(tokenAcceleration));
}
