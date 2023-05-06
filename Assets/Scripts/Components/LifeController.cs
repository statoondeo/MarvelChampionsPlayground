using TMPro;

using UnityEngine;

public sealed class LifeController : MonoBehaviour
{
    [SerializeField] private TMP_Text CurrentText;
    [SerializeField] private TMP_Text MaxText;
    private ILifeComponent Model;
    public void SetModel(ILifeComponent model)
    {
        Model = model;
        Model.Card.Register(ComponentType.Life, OnChangedCallback);
        OnChangedCallback(Model.Card);
    }
    private void OnChangedCallback(ICard model)
    {
        MaxText.text = Model.TotalLife.ToString();
        CurrentText.text = Model.CurrentLife.ToString();
    }
}
