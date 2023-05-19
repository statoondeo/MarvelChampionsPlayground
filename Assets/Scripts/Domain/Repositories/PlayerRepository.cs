public sealed class PlayerRepository : BaseRepository<IPlayer>
{
    private PlayerRepository() : base() { }

    public static IRepository<IPlayer> Get() => new PlayerRepository();
}
