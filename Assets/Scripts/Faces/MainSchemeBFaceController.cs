using UnityEngine;

public sealed class MainSchemeBFaceController : MonoBehaviour
{
    [SerializeField] private AccelerationTokenController AccelerationTokenController;
    [SerializeField] private TreatController TreatController;
    [SerializeField] private TreatThresholdController TreatThresholdController;
    public void SetModel(IMainSchemeBFace model)
    {
        AccelerationTokenController.SetModel(model);
        TreatController.SetModel(model);
        TreatThresholdController.SetModel(model);
    }
}
