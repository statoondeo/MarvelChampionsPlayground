public sealed class AttackFacade : 
    BaseComponentFacade<IAttackComponent>, 
    IAttackFacade
{
    private AttackFacade(IAttackComponent item) 
        : base(item) { }

    #region IAttack

    public int Attack => Item.Attack;

    #endregion

    public static IAttackFacade Get(int attack) 
        => new AttackFacade(AttackComponent.Get(attack));
}