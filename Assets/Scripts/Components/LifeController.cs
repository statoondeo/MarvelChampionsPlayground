using TMPro;

using UnityEngine;

public sealed class LifeController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private ILifeFacade Model;

    public void SetModel(ILifeFacade model)
    {
        Model = model;
        Model.OnChanged += OnChangedCallback;
        OnChangedCallback<ILifeFacade>(null);
    }
    private void OnChangedCallback<ILifeFacade>(ILifeFacade model) => Text.text = Model.Life.ToString();
}
