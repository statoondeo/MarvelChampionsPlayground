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

        transform.GetComponent<ZoneCounterController>()?.SetData(zone);
    }
    public virtual void OnCardAddedCallback(BaseCardController cardController) => PlaceCards(cardController);
    protected abstract void PlaceCards(BaseCardController cardController);
    public abstract void RefreshContent();
}
