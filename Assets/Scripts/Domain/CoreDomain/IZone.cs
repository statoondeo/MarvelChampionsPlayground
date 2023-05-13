public interface IZone : IEntity, IRepository<ICard>
{
    string Id { get; }
    string Label { get; }
    string OwnerId { get; }
    void Shuffle();
    ICard GetLast();
    ICard GetAt(int index);
}
