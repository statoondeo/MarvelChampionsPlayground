public sealed class ZoneRepository : BaseRepository<IZone>
{
    private ZoneRepository() : base() { }

    public static IRepository<IZone> Get() => new ZoneRepository();
}
