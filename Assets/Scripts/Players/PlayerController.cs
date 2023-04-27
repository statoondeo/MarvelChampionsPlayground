using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private IPlayer Player;
    private GameController GameController;
    public CardPositions[] BattlefieldPosition { get; private set; }
    public void SetData(GameController gameController, IPlayer player, CardPositions[] battlefieldPosition)
    {
        GameController = gameController;
        Player = player;
        gameObject.name = Title;
        BattlefieldPosition = battlefieldPosition;
    }
    public string Id => Player.Id;
    public string Title => Player.Title;
    public HeroType HeroType => Player.HeroType;
    public string GetZoneId(string zoneName) => Player.GetZoneId(zoneName);
    public string RegisterZoneId(string zoneName, string zoneId) => Player.RegisterZoneId(zoneName, zoneId);

}
