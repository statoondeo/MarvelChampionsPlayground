using UnityEngine;

public sealed class DeckZoneController : BaseZoneController
{
    [SerializeField] private Transform Sprite;
    public override void RefreshContent()
    {
        transform.localPosition = GameController.Grid.GetWorldPosition(Position);
        foreach (ICard card in Zone.GetAll(NoFilterCardSelector.Get()))
            PlaceCards(GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id)));
    }
    public override void SetData(GameController gameController, IZone zone)
    {
        base.SetData(gameController, zone);
        Zone.AddListener<IShuffleComponent>(OnShuffledCallback);
    }
    private void OnShuffledCallback(IComponent component)
        => GameController.RoutineController.AddAnimation(
            SpinAnimation.Get(
                GameController.RoutineController,
                Sprite,
                    () => Sprite.gameObject.SetActive(true),
                    () => Sprite.gameObject.SetActive(false)));
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