using UnityEngine;

public sealed class HeroFaceController : MonoBehaviour
{
    [SerializeField] private ThwartController ThwartController;
    [SerializeField] private AttackController AttackController;
    [SerializeField] private DefenseController DefenseController;
    [SerializeField] private LifeController LifeController;
    public void SetModel(IHeroFace model)
    {
        ThwartController.SetModel(model);
        AttackController.SetModel(model);
        DefenseController.SetModel(model);
        LifeController.SetModel(model);
    }
}
