using TMPro;

using UnityEngine;

public sealed class DefenseController : BaseCardComponentController<IDefenseComponent>
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private TMP_Text Text;
    protected override void InitValues()
    {
        Text.text = Model.Defense.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<IDefenseComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD"));
    }
}