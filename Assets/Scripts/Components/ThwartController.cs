using TMPro;

using UnityEngine;

public sealed class ThwartController : BaseCardComponentController<IThwartComponent>
{
    [SerializeField] private TMP_Text Text;
    [SerializeField] private Canvas Canvas;
    protected override void InitValues()
    {
        Text.text = Model.Thwart.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<IThwartComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD"));
    }
}