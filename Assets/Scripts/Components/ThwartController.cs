using TMPro;

using UnityEngine;

public sealed class ThwartController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IThwartComponent Model;
    public void SetModel(IThwartComponent model)
    {
        Model = model;
        Model.Card.Register(ComponentType.Thwart, OnChangedCallback);
        OnChangedCallback(Model.Card);
    }
    private void OnChangedCallback(ICard model) => Text.text = Model.Thwart.ToString();
}
