using UnityEngine;

public abstract class BaseCardController : MonoBehaviour, IGridItem
{
    [SerializeField] protected GameObject FacePanelController;
    [SerializeField] protected GameObject BackPanelController;

    #region ICard

    public ICard Card { get; private set; }
    public string Id => Card.Id;
    public string OwnerId => Card.OwnerId;
    public string Location => Card.Location;
    public int Order => Card.Order;

    public void Flip() => Card.Game.Enqueue(FlipToNextCommand.Get(Card.Game, Card));
    public void Tap() => Card.Game.Enqueue(TapCommand.Get(Card.Game, Card));
    public void UnTap() => Card.Game.Enqueue(UnTapCommand.Get(Card.Game, Card));
    public void MoveTo(string newLocation) => Card.Game.Enqueue(MoveToCommand.Get(Card.Game, Card, newLocation));
    public CardType CardType => Card.CardType;

    #endregion

    #region IGridItem

    public Vector2Int Position { get; private set; }
    public void SetPosition(Vector2Int gridPosition) => Position = gridPosition;

    #endregion

    [SerializeField] protected SpriteRenderer SpriteRenderer;
    [SerializeField] protected Transform ImageTransform;
    protected GameController GameController;
    protected RoutineController RoutineController;

    public virtual void SetData(GameController gameController, RoutineController routineController, ICard card)
    {
        GameController = gameController;
        RoutineController = routineController;
        Card = card;
        gameObject.name = (Card.CurrentFace as ITitleComponent).Title;
        SpriteRenderer.sprite = (Card.CurrentFace as ITitleComponent).Sprite;
        Card.AddListener<ICoreCardComponent>(OnCoreCardChangedCallback);
        Card.AddListener<IFlipComponent>(OnFlippedCallback);
        Card.AddListener<ITapComponent>(OnTappedCallback);
        Card.AddListener<ILocationComponent>(OnMovedCallback);
        InitValues();
    }
    public int GetSpriteLayer() => SpriteRenderer.sortingLayerID;
    public int SetSpriteLayer(int layerId) => SpriteRenderer.sortingLayerID = layerId;
    protected virtual void InitValues() { }
    protected virtual void OnCoreCardChangedCallback(IComponent component)
    {
        transform.SetSiblingIndex(Order);
        SpriteRenderer.sortingOrder = Order;
    }

    protected virtual void OnMovedCallback(IComponent component)
    {
        GameController.ZoneControllers.GetFirst(ZoneControllerIdSelector.Get(Card.Location)).OnCardAddedCallback(this);
        InitValues();
    }
    protected virtual void OnFlippedCallback(IComponent component)
        => GameController.RoutineController.AddAnimation(
            FlipAnimation.Get(
                GameController.RoutineController,
                ImageTransform,
                SpriteRenderer,
                (Card.CurrentFace as ITitleComponent).Sprite,
                MidFlipRoutineAction));
    protected virtual void OnTappedCallback(IComponent component)
        => GameController.RoutineController.AddAnimation(
            TapAnimation.Get(
                GameController.RoutineController,
                ImageTransform,
                Card.Tapped));
    protected void MidFlipRoutineAction()
    {
        (Card.IsFace(0) ? FacePanelController : BackPanelController).SetActive(true);
        (Card.IsFace(0) ? BackPanelController : FacePanelController).SetActive(false);
        InitValues();
    }
}
