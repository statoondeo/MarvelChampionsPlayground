using TMPro;

using UnityEngine;

public sealed class SchemeController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private ISchemeComponent Model;

    public void SetModel(ISchemeComponent model)
    {
        Model = model;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Scheme.ToString();
}
