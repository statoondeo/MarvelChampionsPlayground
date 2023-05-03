public sealed class PlayerIdControllerSelector : ISelector<PlayerController>
{
    private readonly string PlayerId;
    private PlayerIdControllerSelector(string playerId) => PlayerId = playerId;
    public bool Match(PlayerController item) => PlayerId.Equals(item.Id);
    public static ISelector<PlayerController> Get(string playerId) => new PlayerIdControllerSelector(playerId);
}
