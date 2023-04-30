using TMPro;

using UnityEngine;

public sealed class DefenseController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IDefenseComponent Model;

    public void SetModel(IDefenseComponent model)
    {
        Model = model;
        //Life.OnChanged += OnChangedCallback;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Defense.ToString();
}