using TMPro;

using UnityEngine;

public sealed class SchemeController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private ISchemeComponent Model;
    public void SetModel(ISchemeComponent model)
    {
        Model = model;
        Model.Card.Register(ComponentType.Scheme, OnChangedCallback);
        OnChangedCallback(Model.Card);
    }
    private void OnChangedCallback(ICard model) => Text.text = Model.Scheme.ToString();
}
