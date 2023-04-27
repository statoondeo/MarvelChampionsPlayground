public sealed class AttackComponent : IAttack
{
    public int Attack { get; private set; }
    private AttackComponent(int attack) => Attack = attack;
    public static IAttack Get(int attack) => new AttackComponent(attack);
}
public interface IAttackFacade : IFacade<IAttack>, IAttack { }
public sealed class AttackFacade : IAttackFacade
{
    private readonly IFacade<IAttack> Facade;
    private AttackFacade(IAttack item) => Facade = FacadeComponent<IAttack>.Get(item);

    #region IFacade<IAttack>

    public IAttack Item { get; private set; }
    public void AddDecorator(IDecorator<IAttack> decorator) => Facade.AddDecorator(decorator);
    public void RemoveDecorator(IDecorator<IAttack> decorator) => Facade.RemoveDecorator(decorator);

    #endregion

    #region IAttack

    public int Attack => Item.Attack;

    #endregion

    public static IAttackFacade Get(int attack) => new AttackFacade(AttackComponent.Get(attack));
}