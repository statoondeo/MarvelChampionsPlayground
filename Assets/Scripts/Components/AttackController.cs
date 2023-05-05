using TMPro;

using UnityEngine;

public sealed class AttackController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IAttackFacade Model;

    public void SetModel(IAttackFacade model)
    {
        Model = model;
        //Model.Register(OnChangedCallback);
        OnChangedCallback<IAttackFacade>(null);
    }
    private void OnChangedCallback<IAttackFacade>(IAttackFacade model) => Text.text = Model.Attack.ToString();
}
