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
        Card.FlipTo("BACK");
        RoutineController.Commit();
    }
    public void UnFlip()
    {
        Card.FlipTo("FACE");
        RoutineController.Commit();
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
        Card.MoveTo(newLocation);
        RoutineController.Commit();
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
        gameObject.name = Card.CurrentFace.Title;
        SpriteRenderer.sprite = Card.CurrentFace.Sprite;
        //Card.Register(OnFlippedCallback);
        //Card.OnTapped += OnTappedCallback;
        //Card.OnUnTapped += OnTappedCallback;
        //Card.OnFlipped += OnFlippedCallback;
        //Card.OnOrderChanged += OnOrderChangedCallback;
        OnOrderChangedCallback(0);
    }
    protected void OnTappedCallback(bool tapped) 
        => RoutineController.TapRoutine(ImageTransform, tapped);
    protected void OnOrderChangedCallback(int order)
    {
        transform.SetSiblingIndex(Card.Order);
        SpriteRenderer.sortingOrder = Card.Order;
    }
    public int GetSpriteLayer() => SpriteRenderer.sortingLayerID;
    public int SetSpriteLayer(int layerId) => SpriteRenderer.sortingLayerID = layerId;
    protected virtual void OnFlippedCallback(IFlipComponent component)
        => RoutineController.FlipRoutine(ImageTransform, SpriteRenderer, Card.CurrentFace.Sprite);
    public void Spin() => RoutineController.SpinRoutine(ImageTransform);
}
