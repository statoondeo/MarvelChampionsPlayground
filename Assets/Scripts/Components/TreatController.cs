using TMPro;

using UnityEngine;

public sealed class TreatController : BaseComponentController<ITreatComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.CurrentTreat.ToString();
}
