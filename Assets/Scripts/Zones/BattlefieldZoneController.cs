﻿using System.Collections.Generic;
using System.Linq;

using TMPro;

using Unity.VisualScripting;

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
        foreach (ICoreCardComponent card in Zone.GetAll(NoFilterCardSelector.Get()))
            PlaceCards(GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id)));
    }
    public override void OnCardAddedCallback(BaseCardController card)
    {
        base.OnCardAddedCallback(card);
        GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id)).AddComponent<DragAndDropController>();
    }
    protected override void PlaceCards(BaseCardController cardController)
    {
        cardController.SetPosition(
            GetEmptySlot(
                cardController.CardType, 
                GameController.PlayerControllers.GetFirst(PlayerIdControllerSelector.Get(cardController.OwnerId)).BattlefieldPosition));
        GameController.Grid.Set(cardController.Position, cardController);
        GameController.RoutineController.AddAnimation(
            MoveAnimation.Get(
                GameController.RoutineController,
                cardController.transform, 
                GameController.Grid.GetWorldPosition(cardController.Position)));
    }
}
