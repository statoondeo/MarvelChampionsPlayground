using TMPro;

using UnityEngine;

public sealed class LifeController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private ILife Model;

    public void SetModel(ILife model)
    {
        Model = model;
        //Life.OnChanged += OnChangedCallback;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Life.ToString();
}
