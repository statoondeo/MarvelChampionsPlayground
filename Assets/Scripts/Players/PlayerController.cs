using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    private IActor Player;
    private GameController GameController;
    public CardPositions[] BattlefieldPosition { get; private set; }
    public void SetData(GameController gameController, IActor player, CardPositions[] battlefieldPosition)
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
    public void RegisterZoneId(string zoneName, string zoneId) => Player.RegisterZoneId(zoneName, zoneId);

}
