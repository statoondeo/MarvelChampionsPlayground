using TMPro;

using UnityEngine;

public sealed class AttackController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IAttackComponent Model;
    public void SetModel(IAttackComponent model)
    {
        Model = model;
        Model.Card.Register(ComponentType.Attack, OnChangedCallback);
        OnChangedCallback(Model.Card);
    }
    private void OnChangedCallback(ICard model) => Text.text = Model.Attack.ToString();
}
