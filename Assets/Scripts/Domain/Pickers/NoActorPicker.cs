public sealed class NoActorPicker : BasePicker<IActor>
{
    private NoActorPicker() : base() { }
    public static IPicker<IActor> Get() => new NoActorPicker();
}
