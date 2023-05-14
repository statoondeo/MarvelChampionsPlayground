using System;

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
