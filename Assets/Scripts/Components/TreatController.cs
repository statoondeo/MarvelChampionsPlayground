using TMPro;

using UnityEngine;

public sealed class TreatController : BaseCardComponentController<ITreatComponent>
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private TMP_Text Text;
    protected override void InitValues()
    {
        Text.text = Model.CurrentTreat.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<ITreatComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD"));
    }
}
