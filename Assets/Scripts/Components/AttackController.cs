using TMPro;

using UnityEngine;

public sealed class AttackController : BaseCardComponentController<IAttackComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.Attack.ToString();
}
