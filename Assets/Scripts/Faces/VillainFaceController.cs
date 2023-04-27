using UnityEngine;

public sealed class VillainFaceController : MonoBehaviour
{
    [SerializeField] private SchemeController SchemeController;
    [SerializeField] private AttackController AttackController;
    [SerializeField] private LifeController LifeController;
    public void SetModel(IVillainFace model)
    {
        SchemeController.SetModel(model);
        AttackController.SetModel(model);
        LifeController.SetModel(model);
    }
}
