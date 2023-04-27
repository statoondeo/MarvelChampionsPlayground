using TMPro;

using UnityEngine;

public sealed class ZoneCounterController : MonoBehaviour
{
    private TMP_Text CounterText;
    private BaseZoneController ZoneController;

    private void Awake()
    {
        CounterText = GetComponentInChildren<TMP_Text>();
        ZoneController = GetComponentInParent<BaseZoneController>();
        ZoneController.OnCardAdded += WriteCounter;
        ZoneController.OnCardRemoved += WriteCounter;
    }
    private void Start() => WriteCounter(null);
    private void WriteCounter(BaseCardController cardController) 
        => CounterText.text = $"{ZoneController.Label} : {ZoneController.Count}";
}