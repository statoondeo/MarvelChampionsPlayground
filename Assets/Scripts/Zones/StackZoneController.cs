public sealed class StackZoneController : BaseZoneController
{
    public override void RefreshContent()
    {
        transform.localPosition = GameController.Grid.GetWorldPosition(Position);
        foreach (ICard card in Zone.GetAll(NoFilterCardSelector.Get()))
            PlaceCards(GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id)));
    }
    protected override void PlaceCards(BaseCardController cardController)
    {
        if (cardController is null) return;
        GameController.RoutineController.AddAnimation(
            MoveAnimation.Get(
                GameController.RoutineController,
                cardController.transform,
                GameController.Grid.GetWorldPosition(Position)));
    }
}
