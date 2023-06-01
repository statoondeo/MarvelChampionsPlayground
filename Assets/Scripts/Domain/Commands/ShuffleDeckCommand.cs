using System.Collections;

public sealed class ShuffleDeckCommand : BaseSingleCommand
{
    private readonly IZone Zone;
    private ShuffleDeckCommand(IGame game, IZone zone) : base(game) => Zone = zone;
    public override IEnumerator Execute()
    {
        Zone.GetFacade<IShuffleComponent>()?.Shuffle();
        yield return base.Execute();
    }

    public static ICommand Get(IGame game, IZone zone) => new ShuffleDeckCommand(game, zone);
}