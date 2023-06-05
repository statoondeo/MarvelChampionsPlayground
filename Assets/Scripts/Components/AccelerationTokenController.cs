using TMPro;

using UnityEngine;

public sealed class AccelerationTokenController : BaseCardComponentController<IAccelerationTokenComponent>
{
    [SerializeField] private TMP_Text Text;
    [SerializeField] private Canvas Canvas;
    protected override void InitValues()
    {
        Text.text = $"+{Model.AccelerationToken}";
        Canvas.gameObject.SetActive(((Model as ICardFace).GetFacade<IAccelerationTokenComponent>() is not null) && Model.Card.IsLocation("BATTLEFIELD") && (Model.AccelerationToken > 0));
    }
}
