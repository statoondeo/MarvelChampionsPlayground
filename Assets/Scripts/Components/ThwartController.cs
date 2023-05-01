using TMPro;

using UnityEngine;

public sealed class ThwartController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IThwartFacade Model;

    public void SetModel(IThwartFacade model)
    {
        Model = model;
        Model.Register(OnChangedCallback);
        OnChangedCallback<IThwartFacade>(null);
    }
    private void OnChangedCallback<IThwartFacade>(IThwartFacade model) => Text.text = Model.Thwart.ToString();
}
