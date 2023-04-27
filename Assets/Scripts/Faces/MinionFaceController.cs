using UnityEngine;

public sealed class MinionFaceController : MonoBehaviour
{
    [SerializeField] private SchemeController SchemeController;
    [SerializeField] private AttackController AttackController;
    [SerializeField] private LifeController LifeController;
    public void SetModel(IMinionFace model)
    {
        SchemeController.SetModel(model);
        AttackController.SetModel(model);
        LifeController.SetModel(model);
    }
}
