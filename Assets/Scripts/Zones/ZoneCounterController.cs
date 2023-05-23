using TMPro;

using UnityEngine;

public sealed class ZoneCounterController : MonoBehaviour
{
    [SerializeField] private TMP_Text CounterText;
    private IZone Zone;

    private void Awake() => CounterText = GetComponentInChildren<TMP_Text>();
    public void SetData(IZone zone)
    {
        Zone = zone;
        Zone.AddListener<ICoreZoneComponent>(WriteCounter);
        WriteCounter(Zone.GetFacade<ICoreZoneComponent>());
    }
    private void WriteCounter(IZoneComponent zone)
    {
        if (zone is not ICoreZoneComponent zoneFacade) return;
        CounterText.text = $"{zoneFacade.Label} : {zoneFacade.Count(NoFilterCardSelector.Get())}";
    }
}