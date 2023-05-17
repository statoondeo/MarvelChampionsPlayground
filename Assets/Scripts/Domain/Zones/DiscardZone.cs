using System;

public sealed class DiscardZone : BaseZone
{
    public DiscardZone(IGame game, string label, string ownerId)
        : base(game, Guid.NewGuid().ToString(), label, ownerId) { }

    public override void Add(ICard card)
    {
        base.Add(card);
        card.UnTap();
        card.FlipTo(0);
    }
}
