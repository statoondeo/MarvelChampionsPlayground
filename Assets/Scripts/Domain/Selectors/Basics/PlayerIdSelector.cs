public sealed class PlayerIdSelector : ISelector<IPlayer>
{
    private readonly string PlayerId;
    private PlayerIdSelector(string playerId) => PlayerId = playerId;
    public bool Match(IPlayer player) => PlayerId.Equals(player.Id);
    public static ISelector<IPlayer> Get(string playerId) => new PlayerIdSelector(playerId);
}