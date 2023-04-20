using UnityEngine;

public sealed class CardController : MonoBehaviour, IGridItem
{
    #region ICard

    public ICard Card { get; private set; }
    public string Id => Card.Id;
    public string OwnerId => Card.OwnerId;
    public string Location => Card.Location;
    public int Order => Card.Order;
    public CardType CardType => Card.CardType;

    public void Flip()
    {
        Card.FlipTo("BACK");
        Card.Game.Mediator.Raise(Events.OnGameCommit);
    }
    public void UnFlip()
    {
        Card.FlipTo("FACE");
        Card.Game.Mediator.Raise(Events.OnGameCommit);
    }
    public void Tap()
    {
        Card.Tap();
        Card.Game.Mediator.Raise(Events.OnGameCommit);
    }
    public void UnTap()
    {
        Card.UnTap();
        Card.Game.Mediator.Raise(Events.OnGameCommit);
    }
    public void MoveTo(string newLocation)
    {
        Card.MoveTo(newLocation);
        Card.Game.Mediator.Raise(Events.OnGameCommit);
    }

    #endregion

    #region IGridItem

    public Vector2Int Position { get; private set; }
    public void SetPosition(Vector2Int gridPosition) => Position = gridPosition;

    #endregion

    private SpriteRenderer SpriteRenderer;
    private Transform ImageTransform;
    private GameController GameController;

    private void Awake()
    {
        ImageTransform = transform.GetChild(0).transform;
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetData(GameController gameController, ICard card)
    {
        GameController = gameController;
        Card = card;
        gameObject.name = Card.CurrentFace.Title;
        SpriteRenderer.sprite = Card.CurrentFace.Sprite;
        Card.OnTapped += OnTappedCallback;
        Card.OnUnTapped += OnTappedCallback;
        Card.OnFlipped += OnFlippedCallback;
        Card.OnOrderChanged += OnOrderChangedCallback;
        OnOrderChangedCallback(0);
    }
    private void OnTappedCallback(bool tapped) 
        => GameController.RoutineService.TapRoutine(ImageTransform, tapped);
    private void OnOrderChangedCallback(int order)
    {
        transform.SetSiblingIndex(Card.Order);
        SpriteRenderer.sortingOrder = Card.Order;
    }

    private void OnFlippedCallback(string face)
        => GameController.RoutineService.FlipRoutine(ImageTransform, SpriteRenderer, Card.CurrentFace.Sprite);
    public void Spin() => GameController.RoutineService.SpinRoutine(ImageTransform);
}
