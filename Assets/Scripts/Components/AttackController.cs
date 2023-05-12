using TMPro;

using UnityEngine;

public sealed class AttackController : BaseComponentController<IAttackComponent>
{
    [SerializeField] private TMP_Text Text;
    protected override void InitValues() => Text.text = Model.Attack.ToString();
}
