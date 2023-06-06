using UnityEngine;

public sealed class UpgradeFaceController : MonoBehaviour
{
    [SerializeField] private CostController CostController;
    public void SetModel(IUpgradeFace model) => CostController.SetModel(model);
}
