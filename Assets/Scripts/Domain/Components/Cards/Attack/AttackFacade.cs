﻿public sealed class AttackFacade : BaseCardComponentFacade<IAttackComponent>, IAttackFacade
{
    private AttackFacade(IAttackComponent item)
        : base(item) { }
    public int Attack => Item.Attack;
    public static IAttackFacade Get(int attack)
        => new AttackFacade(AttackComponent.Get(attack));
}
