public interface IActorHolder
{
    IActor Actor { get; }
    void SetActor(IActor actor);
}
