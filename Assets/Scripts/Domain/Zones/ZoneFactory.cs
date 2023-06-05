using System;

public sealed class ZoneFactory
{
    public IZone Create(IGame game, string label, IActor owner)
    {
        string newId = Guid.NewGuid().ToString();
        return label switch
        {
            "STACK" => StackZone.Get(game, newId, label, owner.Id),
            "DECK" => DeckZone.Get(game, newId, label, owner.Id, owner.HeroType),
            "DISCARD" => DiscardZone.Get(game, newId, label, owner.Id),
            "HAND" => HandZone.Get(game, newId, label, owner.Id),
            "EXIL" => ExilZone.Get(game, newId, label, owner.Id),
            "BOOST" => BoostZone.Get(game, newId, label, owner.Id),
            "ENCOUNTER" => EncounterZone.Get(game, newId, label, owner.Id),
            "BATTLEFIELD" => BattlefieldZone.Get(game, newId, label, owner?.Id),
            _ => null
        };
    }
}