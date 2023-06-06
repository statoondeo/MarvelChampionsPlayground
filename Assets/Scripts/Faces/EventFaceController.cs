using UnityEngine;

public sealed class EventFaceController : MonoBehaviour
{
    [SerializeField] private CostController CostController;
    public void SetModel(IEventFace model) => CostController.SetModel(model);
}
