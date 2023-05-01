using TMPro;

using UnityEngine;

public sealed class RecoveryController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IRecoveryFacade Model;

    public void SetModel(IRecoveryFacade model)
    {
        Model = model;
        Model.Register(OnChangedCallback);
        OnChangedCallback<IRecoveryFacade>(null);
    }
    private void OnChangedCallback<IRecoveryFacade>(IRecoveryFacade model) => Text.text = Model.Recovery.ToString();
}