using TMPro;

using UnityEngine;

public sealed class LifeController : BaseCardComponentController<ILifeComponent>
{
    [SerializeField] private TMP_Text CurrentText;
    [SerializeField] private TMP_Text MaxText;
    [SerializeField] private ParticleSystem ParticleSystem;
    [SerializeField] private int ParticleNumber = 50;
    protected override void InitValues()
    {
        MaxText.text = Model.TotalLife.ToString();
        CurrentText.text = Model.CurrentLife.ToString();
    }
    protected override void OnChangedCallback(IComponent component)
    {
        base.OnChangedCallback(component);
        ParticleSystem.Emit(ParticleNumber);
    }
}
