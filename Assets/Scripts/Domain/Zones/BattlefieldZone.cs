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
