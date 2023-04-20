using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public sealed class BattlefieldZoneController : BaseZoneController
{
    private Vector2Int GetEmptySlot(CardType cardType, CardPositions[] cardPositions)
    {
        List<Vector2Int> typedSlots = cardPositions.FirstOrDefault(item => item.CardType.Equals(cardType))?.Positions.ToList();
        List<Vector2Int> noneSlots = cardPositions.FirstOrDefault(item => item.CardType.Equals(CardType.None)).Positions.ToList();
        if (typedSlots is null) typedSlots = noneSlots;
        else typedSlots.AddRange(noneSlots);

        foreach (Vector2Int position in typedSlots)
            if (GameController.Grid.IsEmpty(position)) return position;
        return Vector2Int.zero;
    }
    public override void RefreshContent()
    {
        foreach (ICard card in Zone)
            PlaceCards(GameController.CardControllers.Get(card.Id));
    }
    protected override void OnCardRemovedCallback(ICard card)
    {
        GameController.Grid.Clear(GameController.CardControllers.Get(card.Id).Position);
        base.OnCardRemovedCallback(card);
    }
    protected override void PlaceCards(CardController cardController)
    {
        cardController.SetPosition(
            GetEmptySlot(cardController.CardType, GameController.PlayerControllers.Get(cardController.OwnerId).BattlefieldPosition));
        GameController.Grid.Set(cardController.Position, cardController);
        GameController.RoutineService.MoveRoutine(cardController.transform, GameController.Grid.GetWorldPosition(cardController.Position));
    }
}
