using System;

public sealed class BattlefieldZone : BaseZone
{
    public BattlefieldZone(IGame game, string label, string ownerId) 
        : base(game, Guid.NewGuid().ToString(), label, ownerId) { }
    public override void Add(ICard card)
    {
        base.Add(card);
        card.GetFacade<IEnterPlayComponent>()?.EnterPlay();
    }
}
public sealed class DeckZone : BaseZone
{
    public DeckZone(IGame game, string label, string ownerId)
        : base(game, Guid.NewGuid().ToString(), label, ownerId) { }

    public override void Add(ICard card)
    {
        base.Add(card);
        card.UnTap();
        card.FlipTo("BACK");
    }
}
public sealed class DiscardZone : BaseZone
{
    public DiscardZone(IGame game, string label, string ownerId)
        : base(game, Guid.NewGuid().ToString(), label, ownerId) { }

    public override void Add(ICard card)
    {
        base.Add(card);
        card.UnTap();
        card.FlipTo("FACE");
    }
}
public sealed class ZoneFactory
{
    public IZone Ceate(IGame game, string label, string ownerId) => label switch
    {
        "DECK" => new DeckZone(game, label, ownerId),
        "DISCARD" => new DiscardZone(game, label, ownerId),
        "BATTLEFIELD" => new BattlefieldZone(game, label, ownerId),
    };
}