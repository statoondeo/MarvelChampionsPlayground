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
    {
        ICard lastCard = Zone.GetLast(NoFilterCardSelector.Get());
        if (lastCard is null) return;
        Sprite.gameObject.SetActive(true);
        GameController.RoutineService.SpinRoutine(Sprite, () => Sprite.gameObject.SetActive(false));
    }
    protected override void PlaceCards(BaseCardController cardController)
    {
        if (cardController is null) return;
        GameController.RoutineService.MoveRoutine(cardController.transform, GameController.Grid.GetWorldPosition(Position));
    }
}