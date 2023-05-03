using TMPro;

using UnityEngine;

public sealed class LifeController : MonoBehaviour
{
    [SerializeField] private TMP_Text CurrentText;
    [SerializeField] private TMP_Text MaxText;
    private ILifeFacade Model;

    public void SetModel(ILifeFacade model)
    {
        Model = model;
        Model.Register(OnChangedCallback);
        OnChangedCallback<ILifeFacade>(null);
    }
    private void OnChangedCallback<ILifeFacade>(ILifeFacade model)
    {
        CurrentText.text = Model.CurrentLife.ToString();
        MaxText.text = Model.TotalLife.ToString();
    }
}
