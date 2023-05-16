using UnityEngine;

public sealed class MainSchemeBFaceController : MonoBehaviour
{
    [SerializeField] private TreatController TreatController;
    public void SetModel(IMainSchemeBFace model) => TreatController.SetModel(model);
}
