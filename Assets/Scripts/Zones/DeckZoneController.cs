﻿public sealed class DeckZoneController : BaseZoneController
{
    public override void RefreshContent()
    {
        transform.localPosition = GameController.Grid.GetWorldPosition(Position);
        foreach (ICoreCardComponent card in Zone)
            PlaceCards(GameController.CardControllers.Get(card.Id));
    }
    public override void SetData(GameController gameController, IZone zone)
    {
        base.SetData(gameController, zone);
        Zone.OnShuffled += OnShuffledCallback;
    }
    private void OnShuffledCallback()
    {
        ICoreCardComponent lastCard = Zone.Last();
        if (lastCard is null) return;
        GameController.CardControllers.Get(lastCard.Id).Spin(); ;
    }
    protected override void PlaceCards(BaseCardController cardController)
    {
        if (cardController is null) return;
        GameController.RoutineService.MoveRoutine(cardController.transform, GameController.Grid.GetWorldPosition(Position));
    }
}