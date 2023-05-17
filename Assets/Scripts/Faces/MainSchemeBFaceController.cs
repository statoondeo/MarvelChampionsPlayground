using UnityEngine;

public sealed class MainSchemeBFaceController : MonoBehaviour
{
    [SerializeField] private TreatController TreatController;
    [SerializeField] private TreatThresholdController TreatThresholdController;
    public void SetModel(IMainSchemeBFace model)
    {
        TreatController.SetModel(model);
        TreatThresholdController.SetModel(model);
    }
}
