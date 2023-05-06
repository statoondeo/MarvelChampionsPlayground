using TMPro;

using UnityEngine;

public sealed class RecoveryController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IRecoveryComponent Model;
    public void SetModel(IRecoveryComponent model)
    {
        Model = model;
        Model.Card.Register(ComponentType.Recovery, OnChangedCallback);
        OnChangedCallback(Model.Card);
    }
    private void OnChangedCallback(ICard model) => Text.text = Model.Recovery.ToString();
}