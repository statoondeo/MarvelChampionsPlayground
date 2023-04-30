public sealed class ShuffleZoneCommand : BaseCommand
{
    private readonly IZone Zone;
    private ShuffleZoneCommand(IGame game, IZone zone) : base(game) => Zone = zone;
    public override void Execute() => Zone.Shuffle();
    public static ICommand Get(IGame game, IZone zone) => new ShuffleZoneCommand(game, zone);
}