using TMPro;

using UnityEngine;

public sealed class SchemeController : BaseComponentController<ISchemeComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.Scheme.ToString();
}