public interface ILifeComponent : ICardComponent<ILifeComponent>
{
    int CurrentLife { get; }
    int TotalLife { get; }
    int Damage { get; }
    void TakeDamage(int damage);
    void HealDamage(int damage);
}
