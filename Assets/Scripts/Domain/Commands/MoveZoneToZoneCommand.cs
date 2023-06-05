using System.Collections;
using System.Linq;

public sealed class MoveZoneToZoneCommand : BaseCommand
{
    private readonly string OwnerId;
    private readonly string FromLocation;
    private readonly string ToLocation;
    private MoveZoneToZoneCommand(IGame game, string ownerId, string fromLocation, string toLocation) : base(game)
    {
        OwnerId = ownerId;
        FromLocation = fromLocation;
        ToLocation = toLocation;
    }
    public override IEnumerator Execute()
    {
        Game.GetAll(
            AndCompositeSelector.Get(
                LocationSelector.Get(FromLocation),
                OwnerIdSelector.Get(OwnerId)))
            .ToList()
            .ForEach(card => Game.Enqueue(MoveToCommand.Get(Game, card, ToLocation)));
        Executed = true;
        yield return null;
    }

    public static ICommand Get(IGame game, string ownerId, string fromLocation, string toLocation) 
        => new MoveZoneToZoneCommand(game, ownerId, fromLocation, toLocation);
}