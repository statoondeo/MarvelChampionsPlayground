public sealed class ComponentEvent : BaseEvent<IComponent>
{
    private ComponentEvent() : base() { }
    public static IEvent<IComponent> Get() => new ComponentEvent();
}