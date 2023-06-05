public abstract class BaseAccelerationTokenDecorator :
    BaseCardComponentDecorator<IAccelerationTokenComponent>,
    IAccelerationTokenComponent
{
    protected BaseAccelerationTokenDecorator() : base() { }
    public int AccelerationToken => InnerComponent.AccelerationToken;
}
