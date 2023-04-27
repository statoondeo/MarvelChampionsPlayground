public sealed class NullCommand : ICommand
{
    private NullCommand() { }
    public void Execute() { }
    public static ICommand Get() => new NullCommand();
}
