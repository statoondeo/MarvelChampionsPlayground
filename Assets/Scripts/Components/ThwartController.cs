using TMPro;

using UnityEngine;

public sealed class ThwartController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IThwartComponent Model;

    public void SetModel(IThwartComponent model)
    {
        Model = model;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Thwart.ToString();
}
