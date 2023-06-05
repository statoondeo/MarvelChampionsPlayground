using UnityEngine;

public sealed class AllyFaceController : MonoBehaviour
{
    [SerializeField] private CostController CostController;
    [SerializeField] private ThwartController ThwartController;
    [SerializeField] private AttackController AttackController;
    [SerializeField] private LifeController LifeController;

    public void SetModel(IAllyFace model)
    {
        CostController.SetModel(model);
        ThwartController.SetModel(model);
        AttackController.SetModel(model);
        LifeController.SetModel(model);
    }
}
