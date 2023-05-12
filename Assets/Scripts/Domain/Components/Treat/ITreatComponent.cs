public interface ITreatComponent : IComponent<ITreatComponent>
{
    int CurrentTreat { get; }
    void AddTreat(int treat);
    void RemoveTreat(int treat);
}
