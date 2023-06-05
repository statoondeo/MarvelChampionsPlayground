using TMPro;

using UnityEngine;

public sealed class SchemeController : BaseCardComponentController<ISchemeComponent>
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private TMP_Text Text;
    protected override void InitValues()
    {
        Text.text = Model.Scheme.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<ISchemeComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD"));
    }
}