using System.Collections;

public sealed class DealEncounterCardCommand : BaseSingleCommand
{
    private readonly IVillainActor FromVillain;
    private readonly IPlayerActor TargetPlayer;
    private DealEncounterCardCommand(IGame game, IVillainActor fromVillain, IPlayerActor player) : base(game)
    {
        FromVillain = fromVillain;
        TargetPlayer = player;
    }
    public override IEnumerator Execute()
    {
        FromVillain.DealEncounterCard(TargetPlayer, 1);
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, IVillainActor fromVillain, IPlayerActor targetPlayer) 
        => new DealEncounterCardCommand(game, fromVillain, targetPlayer);
}