public sealed class SingleAccelerationTokenDecorator :
    BaseCardComponentDecorator<IAccelerationTokenComponent>,
    IAccelerationTokenComponent
{
    private SingleAccelerationTokenDecorator() : base() { }
    public int AccelerationToken => InnerComponent.AccelerationToken + 1;
    public static ICardComponentDecorator<IAccelerationTokenComponent> Get() => new SingleAccelerationTokenDecorator();
}