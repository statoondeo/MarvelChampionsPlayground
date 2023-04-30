using TMPro;

using UnityEngine;

public sealed class AttackController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IAttackComponent Model;

    public void SetModel(IAttackComponent model)
    {
        Model = model;
        //Life.OnChanged += OnChangedCallback;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Attack.ToString();
}
