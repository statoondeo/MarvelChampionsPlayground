public sealed class PlayerIdSelector : ISelector<IActor>
{
    private readonly string PlayerId;
    private PlayerIdSelector(string playerId) => PlayerId = playerId;
    public bool Match(IActor player) => PlayerId.Equals(player.Id);
    public static ISelector<IActor> Get(string playerId) => new PlayerIdSelector(playerId);
}