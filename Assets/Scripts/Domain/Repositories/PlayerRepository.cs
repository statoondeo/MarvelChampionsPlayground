public sealed class PlayerRepository : BaseRepository<IActor>
{
    private PlayerRepository() : base() { }

    public static IRepository<IActor> Get() => new PlayerRepository();
}
