using UnityEngine;

public sealed class AlterEgoFaceController : MonoBehaviour
{
    [SerializeField] private RecoveryController RecoveryController;
    public void SetModel(IAlterEgoFacade model) => RecoveryController.SetModel(model);
}
