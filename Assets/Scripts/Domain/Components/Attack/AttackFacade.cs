using System;

public sealed class AttackFacade : IAttackFacade
{
    private readonly IFacade<IAttackComponent> Facade;
    private AttackFacade(IAttackComponent item) => Facade = FacadeComponent<IAttackComponent>.Get(item);

    #region IFacade<IAttack>

    public IAttackComponent Item { get; private set; }
    public void AddDecorator(IDecorator<IAttackComponent> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IAttackComponent> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IAttack

    public Action<IAttackComponent> OnChanged { get => Item.OnChanged; set => Item.OnChanged = value; }
    public int Attack => Item.Attack;

    #endregion

    public static IAttackFacade Get(int attack) => new AttackFacade(AttackComponent.Get(attack));
}