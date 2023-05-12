using TMPro;

using UnityEngine;

public sealed class DefenseController : BaseComponentController<IDefenseComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.Defense.ToString();
}