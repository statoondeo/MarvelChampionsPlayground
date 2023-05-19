using TMPro;

using UnityEngine;

public sealed class SchemeController : BaseCardComponentController<ISchemeComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.Scheme.ToString();
}