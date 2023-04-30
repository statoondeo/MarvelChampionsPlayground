using UnityEngine;

public sealed class AlterEgoFaceController : MonoBehaviour
{
    [SerializeField] private RecoveryController RecoveryController;
    public void SetModel(IAlterEgoFace model) => RecoveryController.SetModel(model);
}
