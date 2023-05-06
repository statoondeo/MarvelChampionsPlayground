using UnityEngine;
public abstract class BaseCardController : MonoBehaviour, IGridItem
{
    #region ICard

    public ICard Card { get; private set; }
    public string Id => Card.Id;
    public string OwnerId => Card.OwnerId;
    public string Location => Card.Location;
    public int Order => Card.Order;

    public void Flip()
    {
        CompositeCommand.Get(
            FlipToCommand.Get(Card.Game, Card, "BACK"),
            CommitGameCommand.Get(Card.Game))
            .Execute();
    }
    public void UnFlip()
    {
        CompositeCommand.Get(
            FlipToCommand.Get(Card.Game, Card, "FACE"),
            CommitGameCommand.Get(Card.Game))
            .Execute();
    }
    public void Tap()
    {
        Card.Tap();
        RoutineController.Commit();
    }
    public void UnTap()
    {
        Card.UnTap();
        RoutineController.Commit();
    }
    public void MoveTo(string newLocation)
    {
        CompositeCommand.Get(
            MoveToCommand.Get(Card.Game, Card, newLocation),
            CommitGameCommand.Get(Card.Game))
            .Execute();
    }
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
        Card.Register(ComponentType.Flip, OnFlippedCallback);
    }
    public int GetSpriteLayer() => SpriteRenderer.sortingLayerID;
    public int SetSpriteLayer(int layerId) => SpriteRenderer.sortingLayerID = layerId;
    protected virtual void OnFlippedCallback(IFlipComponent component)
        => RoutineController.FlipRoutine(ImageTransform, SpriteRenderer, (Card.CurrentFace as ITitleComponent).Sprite);
}
