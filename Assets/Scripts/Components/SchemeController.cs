using TMPro;

using UnityEngine;

public sealed class SchemeController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IScheme Model;

    public void SetModel(IScheme model)
    {
        Model = model;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Scheme.ToString();
}
