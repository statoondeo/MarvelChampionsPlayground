using TMPro;

using UnityEngine;

public sealed class AttackController : BaseCardComponentController<IAttackComponent>
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private TMP_Text Text;
    protected override void InitValues()
    {
        Text.text = Model.Attack.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<IAttackComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD"));
    }
}
