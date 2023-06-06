using UnityEngine;

public sealed class SupportFaceController : MonoBehaviour
{
    [SerializeField] private CostController CostController;
    public void SetModel(ISupportFace model) => CostController.SetModel(model);
}
