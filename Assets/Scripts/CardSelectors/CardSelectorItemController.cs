using UnityEngine;

public sealed class CardSelectorItemController : MonoBehaviour
{
    public bool IsActive { get; private set; }
    public bool IsSelectable { get; private set; }
    public bool IsSelected { get; private set; }
    public ICard Card { get; private set; }

    [SerializeField] private SpriteRenderer SelectedImage;
    [SerializeField] private SpriteRenderer SelectableImage;

    private ISelectionMediator Mediator;
    private void Start() => Reset();
    private void Reset()
    {
        SelectedImage.gameObject.SetActive(false);
        SelectableImage.gameObject.SetActive(false);
    }
    private void MakeSelectable() => SelectableImage.gameObject.SetActive(IsActive && !IsSelectable);
    private void MakeSelection(bool isSelected)
    {
        if (!IsActive || !IsSelectable) return;
        IsSelected = isSelected;
        SelectedImage.gameObject.SetActive(IsSelected);
        Mediator.Raise(IsSelected ? SelectionEvent.OnItemSelected : SelectionEvent.OnItemUnSelected, OnItemSelectionEventParam.Get(Card));
    }
    public void SetCard(ICard card, bool selected = false)
    {
        Card = card;
        MakeSelection(selected);
    }
    public void SetSelectionMediator(ISelectionMediator mediator)
    {
        Mediator = mediator;
        Mediator.AddListener(SelectionEvent.OnSelectionStarted, OnSelectionStartedCallback);
        Mediator.AddListener(SelectionEvent.OnSelectionEnded, OnSelectionEndedCallback);
    }
    private void OnSelectionStartedCallback(ISelectionEventParam eventParam)
    {
        if (eventParam is not OnSelectionStartedEventParam onSelectionStartedEventParam) return;
        IsActive = true;
        IsSelectable = onSelectionStartedEventParam.Selector.Match(Card);
        MakeSelectable();
        MakeSelection(onSelectionStartedEventParam.IsSelected);
    }
    private void OnSelectionEndedCallback(ISelectionEventParam eventParam)
    {
        IsActive = false;
        Reset();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MakeSelection(!IsSelected);
        }
    }
}
