public interface ITreatComponent : ICardComponent<ITreatComponent>
{
    int CurrentTreat { get; }
    void AddTreat(int treat);
    void RemoveTreat(int treat);
}
