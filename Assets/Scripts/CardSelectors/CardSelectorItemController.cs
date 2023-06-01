using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class CardSelectorItemController : MonoBehaviour, IPointerClickHandler
{
    public bool Selected { get; private set; }
    public ICard Card { get; private set; }
    [SerializeField] private Image TickImage;
    private Image Image;

    private void SwitchSelected()
    {
        Selected = !Selected;
        TickImage.enabled = Selected;
    }
    public void SetCard(ICard card, bool selected = false)
    {
        Image = GetComponent<Image>();
        Card = card;
        Image.sprite = Card.CurrentFace.GetFacade<ITitleComponent>().Sprite;
        Selected = selected;
        TickImage.enabled = Selected;

    }
    public void OnPointerClick(PointerEventData eventData) => SwitchSelected();
}
