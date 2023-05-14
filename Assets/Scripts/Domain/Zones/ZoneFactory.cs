public sealed class ZoneFactory
{
    public IZone Ceate(IGame game, string label, string ownerId) => label switch
    {
        "DECK" => new DeckZone(game, label, ownerId),
        "DISCARD" => new DiscardZone(game, label, ownerId),
        "BATTLEFIELD" => new BattlefieldZone(game, label, ownerId),
        _ => null
    };
}