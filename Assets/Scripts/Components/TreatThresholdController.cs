using TMPro;

using UnityEngine;

public sealed class TreatThresholdController : BaseCardComponentController<ITreatThresholdComponent>
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private TMP_Text Text;
    protected override void InitValues()
    {
        Text.text = Model.TreatThreshold.ToString();
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<ITreatThresholdComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD"));
    }
}