public sealed class DeckZoneController : BaseZoneController
{
    public override void RefreshContent()
    {
        transform.localPosition = GameController.Grid.GetWorldPosition(Position);
        foreach (ICard card in Zone.GetAll(NoFilterCardSelector.Get()))
            PlaceCards(GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id)));
    }
    public override void SetData(GameController gameController, IZone zone)
    {
        base.SetData(gameController, zone);
    }
    private void OnShuffledCallback()
    {
        ICard lastCard = Zone.GetLast(NoFilterCardSelector.Get());
        if (lastCard is null) return;
        //GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(lastCard.Id)).Spin(); ;
    }
    protected override void PlaceCards(BaseCardController cardController)
    {
        if (cardController is null) return;
        GameController.RoutineService.MoveRoutine(cardController.transform, GameController.Grid.GetWorldPosition(Position));
    }
}