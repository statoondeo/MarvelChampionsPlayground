public sealed class StandardActorHolder : IActorHolder
{
    private StandardActorHolder() { }
    public IActor Actor { get; private set; }
    public void SetActor(IActor actor) => Actor = actor;
    public static IActorHolder Get() => new StandardActorHolder();
}
