using TMPro;

using UnityEngine;

public sealed class AttackController : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    private IAttack Model;

    public void SetModel(IAttack model)
    {
        Model = model;
        //Life.OnChanged += OnChangedCallback;
        OnChangedCallback();
    }
    private void OnChangedCallback() => Text.text = Model.Attack.ToString();
}
