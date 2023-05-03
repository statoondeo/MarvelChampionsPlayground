public sealed class CommitGameCommand : BaseCommand
{
    private CommitGameCommand(IGame game) : base(game) { }
    public override void Execute() => Game.Commit();
    private static ICommand Command;
    public static ICommand Get(IGame game) => Command is null ? Command = new CommitGameCommand(game) : Command;
}
