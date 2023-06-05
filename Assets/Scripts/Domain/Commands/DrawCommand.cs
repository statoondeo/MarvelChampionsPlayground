using System.Collections;

public sealed class DrawCommand : BaseSingleCommand
{
    private readonly IPlayerActor Player;
    private DrawCommand(IGame game, IPlayerActor player) : base(game) => Player = player;
    public override IEnumerator Execute()
    {
        Player.Draw(1);
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, IPlayerActor player) => new DrawCommand(game, player);
}
