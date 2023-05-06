using TMPro;

using UnityEngine;

public sealed class DefenseController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IDefenseComponent Model;
    public void SetModel(IDefenseComponent model)
    {
        Model = model;
        Model.Card.Register(ComponentType.Defense, OnChangedCallback);
        OnChangedCallback(Model.Card);
    }
    private void OnChangedCallback(ICard model) => Text.text = Model.Defense.ToString();
}