public interface ILifeComponent : IComponent<ILifeComponent>
{
    int CurrentLife { get; }
    int TotalLife { get; }
    int Damage { get; }
    void TakeDamage(int damage);
}
