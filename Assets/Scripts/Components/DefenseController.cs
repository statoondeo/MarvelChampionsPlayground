using TMPro;

using UnityEngine;

public sealed class DefenseController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IDefenseFacade Model;

    public void SetModel(IDefenseFacade model)
    {
        Model = model;
        Model.OnChanged += OnChangedCallback;
        OnChangedCallback<IDefenseFacade>(null);
    }
    private void OnChangedCallback<IDefenseFacade>(IDefenseFacade model) => Text.text = Model.Defense.ToString();
}