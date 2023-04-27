using TMPro;

using UnityEngine;

public sealed class ThwartController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IThwart Model;

    public void SetModel(IThwart model)
    {
        Model = model;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Thwart.ToString();
}
