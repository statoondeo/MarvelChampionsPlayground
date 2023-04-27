using UnityEngine;

public sealed class AllyFaceController : MonoBehaviour
{
    [SerializeField] private ThwartController ThwartController;
    [SerializeField] private AttackController AttackController;
    [SerializeField] private LifeController LifeController;
    public void SetModel(IAllyFacade model)
    {
        ThwartController.SetModel(model);
        AttackController.SetModel(model);
        LifeController.SetModel(model);
    }
}
