using UnityEngine;
using UnityEngine.EventSystems;

public sealed class OnHoverZoneController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private CanvasGroup CanvasGroup;
    private void Awake() => CanvasGroup.alpha = .0f;
    public void OnPointerEnter(PointerEventData eventData) => CanvasGroup.alpha = 1.0f;
    public void OnPointerExit(PointerEventData eventData) => CanvasGroup.alpha = .0f;
}