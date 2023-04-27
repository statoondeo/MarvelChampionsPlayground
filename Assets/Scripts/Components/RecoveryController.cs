using TMPro;

using UnityEngine;

public sealed class RecoveryController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IRecovery Model;

    public void SetModel(IRecovery model)
    {
        Model = model;
        //Life.OnChanged += OnChangedCallback;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Recovery.ToString();
}
