using TMPro;

using UnityEngine;

public sealed class SchemeController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private ISchemeFacade Model;

    public void SetModel(ISchemeFacade model)
    {
        Model = model;
        Model.OnChanged += OnChangedCallback;
        OnChangedCallback<ISchemeFacade>(null);
    }
    private void OnChangedCallback<ISchemeFacade>(ISchemeFacade model) => Text.text = Model.Scheme.ToString();
}
