using System;

public sealed class ZoneFactory
{
    public IZone Create(IGame game, string label, string ownerId)
    {
        string newId = Guid.NewGuid().ToString();
        return label switch
        {
            "STACK" => StackZone.Get(game, newId, label, ownerId),
            "DECK" => DeckZone.Get(game, newId, label, ownerId),
            "DISCARD" => DiscardZone.Get(game, newId, label, ownerId),
            "HAND" => HandZone.Get(game, newId, label, ownerId),
            "EXIL" => ExilZone.Get(game, newId, label, ownerId),
            "BOOST" => BoostZone.Get(game, newId, label, ownerId),
            "ENCOUNTER" => EncounterZone.Get(game, newId, label, ownerId),
            "BATTLEFIELD" => BattlefieldZone.Get(game, newId, label, ownerId),
            _ => null
        };
    }
}