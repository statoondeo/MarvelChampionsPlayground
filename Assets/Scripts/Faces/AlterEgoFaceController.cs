using UnityEngine;

public sealed class AlterEgoFaceController : MonoBehaviour
{
    [SerializeField] private RecoveryController RecoveryController;
    [SerializeField] private LifeController LifeController;
    public void SetModel(IAlterEgoFace model)
    {
        RecoveryController.SetModel(model);
        LifeController.SetModel(model);
    }
}
