using System;

using UnityEngine;
public abstract class BaseZoneController : MonoBehaviour, IGridItem
{
    #region IZone

    protected IZone Zone;
    public string Id => Zone.Id;
    public string Label => Zone.Label;
    public string OwnerId => Zone.OwnerId;
    public int Count => Zone.Count(NoFilterCardSelector.Get());

    public void AddCard(BaseCardController cardController) => Zone.Add(cardController.Card);

    #endregion

    #region IGridItem

    public Vector2Int Position { get; protected set; }
    public void SetPosition(Vector2Int gridPosition) => Position = gridPosition;

    #endregion

    protected GameController GameController;
    public Action<BaseCardController> OnCardAdded;
    public Action<BaseCardController> OnCardRemoved;
    public virtual void SetData(GameController gameController, IZone zone)
    {
        GameController = gameController;
        Zone = zone;
        gameObject.name = Zone.Label;
    }
    protected virtual void OnCardAddedCallback(ICoreCardComponent card)
    {
        BaseCardController cardController = GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id));
        PlaceCards(cardController);
        OnCardRemoved?.Invoke(cardController);
    }
    protected virtual void OnCardRemovedCallback(ICoreCardComponent card) 
        => OnCardRemoved?.Invoke(GameController.CardControllers.GetFirst(CardIdControllerSelector.Get(card.Id)));
    protected abstract void PlaceCards(BaseCardController cardController);
    public abstract void RefreshContent();
}
