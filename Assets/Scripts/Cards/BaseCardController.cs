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

    public void Flip() 
        => CompositeCommand.Get(
            FlipToCommand.Get(Card.Game, Card, "BACK"),
            CommitRoutineCommand.Get(RoutineController))
            .Execute();
    public void UnFlip() 
        => CompositeCommand.Get(
            FlipToCommand.Get(Card.Game, Card, "FACE"),
            CommitRoutineCommand.Get(RoutineController))
            .Execute();
    public void Tap() 
        => CompositeCommand.Get(
            TapCommand.Get(Card.Game, Card),
            CommitRoutineCommand.Get(RoutineController))
            .Execute();
    public void UnTap() 
        => CompositeCommand.Get(
            UnTapCommand.Get(Card.Game, Card),
            CommitRoutineCommand.Get(RoutineController))
            .Execute();
    public void MoveTo(string newLocation) 
        => CompositeCommand.Get(
            MoveToCommand.Get(Card.Game, Card, newLocation),
            CommitRoutineCommand.Get(RoutineController))
            .Execute();
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
        Card.AddListener<IFlipComponent>(OnFlippedCallback);
        Card.AddListener<ITapComponent>(OnTappedCallback);
        Card.AddListener<ILocationComponent>(OnMovedCallback);
        InitValues();
    }
    public int GetSpriteLayer() => SpriteRenderer.sortingLayerID;
    public int SetSpriteLayer(int layerId) => SpriteRenderer.sortingLayerID = layerId;
    protected virtual void InitValues() { }
    protected virtual void OnMovedCallback(IComponent component) => InitValues();
    protected virtual void OnFlippedCallback(IComponent component)
        => RoutineController.FlipRoutine(
                ImageTransform,
                SpriteRenderer,
                (Card.CurrentFace as ITitleComponent).Sprite,
                MidFlipRoutineAction);

    protected virtual void OnTappedCallback(IComponent component)
        => RoutineController.TapRoutine(ImageTransform, (component as ITapComponent).Tapped);
    protected void MidFlipRoutineAction()
    {
        (Card.IsFace("FACE") ? FacePanelController : BackPanelController).SetActive(true);
        (Card.IsFace("FACE") ? BackPanelController : FacePanelController).SetActive(false);
        InitValues();
    }
}
