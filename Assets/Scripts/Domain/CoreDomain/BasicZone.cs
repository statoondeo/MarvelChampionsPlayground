using System;

public sealed class BasicZone : BaseZone
{
    public BasicZone(IGame game, string label, string ownerId) 
        : base(game, Guid.NewGuid().ToString(), label, ownerId) { }
}
