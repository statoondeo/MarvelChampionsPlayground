public sealed class AccelerationTokenComponent
    : BaseCardComponent<IAccelerationTokenComponent>,
        IAccelerationTokenComponent
{
    public int AccelerationToken { get; private set; }
    private AccelerationTokenComponent(int tokenAcceleration)
        : base()
    {
        AccelerationToken = tokenAcceleration;
    }
    public static IAccelerationTokenComponent Get(int tokenAcceleration)
        => new AccelerationTokenComponent(tokenAcceleration);
}
