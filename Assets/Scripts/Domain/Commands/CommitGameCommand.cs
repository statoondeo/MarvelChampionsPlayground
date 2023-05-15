public sealed class CommitGameCommand : BaseCommand
{
    private CommitGameCommand(IGame game) : base(game) { }
    public override void Execute() => Game.Commit();
    public static ICommand Get(IGame game) => new CommitGameCommand(game);
}
