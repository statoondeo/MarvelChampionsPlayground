public interface ICoreZoneComponent : IRepository<ICard>, IZoneComponent<ICoreZoneComponent>
{
    string Id { get; }
    string Label { get; }
    string OwnerId { get; }
}
