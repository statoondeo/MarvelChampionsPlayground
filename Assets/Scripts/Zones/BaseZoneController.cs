using System.Linq;

using UnityEngine;

public abstract class BaseZoneController : MonoBehaviour, IGridItem
{
    protected IZone Zone;
    public string Id => Zone.Id;
    public string Label => Zone.Label;
    public int Count => Zone.Count(NoFilterCardSelector.Get());

    #region IGridItem

    public Vector2Int Position { get; protected set; }
    public void SetPosition(Vector2Int gridPosition) => Position = gridPosition;

    #endregion

    protected GameController GameController;
    public virtual void SetData(GameController gameController, IZone zone)
    {
        GameController = gameController;
        Zone = zone;
        gameObject.name = Zone.Label;
        Zone.AddListener<ICoreZoneComponent>(OnCardAddedCallback);
        transform.GetComponent<ZoneCounterController>()?.SetData(zone);
    }
    public virtual void OnCardAddedCallback(IZoneComponent component) => PlaceCards();
    protected virtual void PlaceCards() 
        => Zone
            .GetAll(NoFilterCardSelector.Get())
            .ToList()
            .ForEach(card =>
            {
                BaseCardController cardController = GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id));
                if (cardController.Position == Position) return;
                cardController.SetPosition(Position);
                GameController.RoutineController.AddAnimation(
                    MoveAnimation.Get(
                        GameController.RoutineController,
                        cardController.transform,
                        GameController.Grid.GetWorldPosition(Position)));
            });
    public abstract void RefreshContent();
}
