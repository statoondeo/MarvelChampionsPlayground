using TMPro;

using UnityEngine;

public sealed class RecoveryController : BaseCardComponentController<IRecoveryComponent>
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private TMP_Text Text;
    protected override void InitValues()
    {
        Text.text = Model.Recovery.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<IRecoveryComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD"));
    }
}