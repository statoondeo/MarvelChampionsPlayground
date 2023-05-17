using TMPro;

using UnityEngine;

public sealed class TreatThresholdController : BaseComponentController<ITreatThresholdComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.TreatThreshold.ToString();
}