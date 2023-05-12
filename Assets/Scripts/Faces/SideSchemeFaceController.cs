using UnityEngine;

public sealed class SideSchemeFaceController : MonoBehaviour
{
    [SerializeField] private TreatController TreatController;
    public void SetModel(ISideSchemeFace model) => TreatController.SetModel(model);
}
