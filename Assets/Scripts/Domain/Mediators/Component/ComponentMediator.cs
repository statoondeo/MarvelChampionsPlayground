public sealed class ComponentMediator : BaseMediator<IComponent>
{
    private ComponentMediator() : base(ComponentEvent.Get) { }
    public static IMediator<IComponent> Get() => new ComponentMediator();
}